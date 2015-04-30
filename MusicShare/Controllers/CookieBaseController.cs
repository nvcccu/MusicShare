using System;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.PasswordHelper;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Controllers {
    public class CookieBaseController : Controller {
        private const string GuestCookieName = "GuestId";
        protected const string AuthCookieName = "MgAuth";
        private long? _guestId;
        protected long GuestId {
            get {
                if (_guestId == null) {
                    _guestId = TryGetGuestIdFromCookie();
                    _guestId = _guestId ?? GetNextGuestId();
                }
                return _guestId.Value;
            }
            private set {
                _guestId = value;
            }
        }
        private int? _id;
        protected int? Id {
            get {
                if (!_id.HasValue) {
                    _id = GetIdFromAuthCookie();
                }
                return _id;
            }
        }

        private long? TryGetGuestIdFromCookie() {
            long? guestId = null;
            var guestIdCookie = Request.Cookies.Get(GuestCookieName);
            if (guestIdCookie != null) {
                guestId = Convert.ToInt64(guestIdCookie.Value);
            }
            return guestId;
        }
        private long GetNextGuestId() {
            return ServiceManager<IBusinessLogic>.Instance.Service.GetNextGuestId(Request.UserAgent);
        }
        private void CheckGuestIdCookieIsSet() {
            var guestIdCookie = Request.Cookies[GuestCookieName];
            if (guestIdCookie == null || guestIdCookie.Value == null) {
                var guestId = GetNextGuestId();
                guestIdCookie = guestIdCookie ?? new HttpCookie(GuestCookieName, guestId.ToString()) {
                    Expires = new DateTime(DateTime.Now.AddYears(5).Year, 1, 1)
                };
                Response.Cookies.Add(guestIdCookie);
            }
        }
        protected void SetAuthCookie(long guestId, int id, bool rememberMe) {
            var expirationDate = rememberMe ? DateTime.Now.AddYears(1) : DateTime.MinValue;
            var encryptedAuthCookieValue = PasswordHelper.EncryptInt(id);
            var authCookie = Request.Cookies[AuthCookieName];
            var guestCookie = Request.Cookies[GuestCookieName];
            if (authCookie != null) {
                authCookie.Value = encryptedAuthCookieValue;
                authCookie.Expires = expirationDate;
            } else {
                Response.Cookies.Add(new HttpCookie(AuthCookieName, encryptedAuthCookieValue) {
                    Expires = expirationDate
                });
            }
            if (guestCookie != null) {
                Request.Cookies.Remove(GuestCookieName);
            }
            Response.Cookies.Add(new HttpCookie(GuestCookieName, guestId.ToString()) {
                Expires = new DateTime(DateTime.Now.AddYears(5).Year, 1, 1)
            });
            GuestId = guestId;
            
        }
        public int? GetIdFromAuthCookie() {
            int? id = null;
            var authCookie = Request.Cookies[AuthCookieName];
            if (authCookie != null) {
                var authCookieValue = authCookie.Value;
                if (authCookieValue != null) {
                    id = PasswordHelper.DecryptInt(authCookieValue);
                }
            }
            return id;
        }
        // Не использовать лишний раз этот метод. Сделан для того, чтобы у двух аккаунтов не могло быть одинакового GuestId'а
        protected void RegenerateGuestId() {
            Response.Cookies.Remove(GuestCookieName);
            var guestId = GetNextGuestId();
            var guestIdCookie = new HttpCookie(GuestCookieName, guestId.ToString()) {
                Expires = new DateTime(DateTime.Now.AddYears(5).Year, 1, 1)
            };
            Response.Cookies.Add(guestIdCookie);
            GuestId = guestId;
        }
        protected override bool DisableAsyncSupport {
            get { return true; }
        }
        protected override void ExecuteCore() {
            CheckGuestIdCookieIsSet();
            base.ExecuteCore();
        }
    }
}