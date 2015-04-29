using System;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.PasswordHelper;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Controllers {
    public class CookieBaseController : Controller {
        private const string GuestIdCookieName = "GuestId";
        protected const string AuthCookieName = "MgAuth";
        private long? _guestId;
        protected long GuestId {
            get { return _guestId ?? SetGuestIdCookie(); }
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

        private long SetGuestIdCookie() {
            var guestIdCookie = Request.Cookies.Get(GuestIdCookieName);
            if (guestIdCookie != null) {
                _guestId = Convert.ToInt64(guestIdCookie.Value);
            } else {
                _guestId = ServiceManager<IBusinessLogic>.Instance.Service.GetNextGuestId(Request.UserAgent);
                guestIdCookie = new HttpCookie(GuestIdCookieName, _guestId.ToString()) {
                    Expires = new DateTime(DateTime.Now.AddYears(5).Year, 1, 1)
                };
                Response.Cookies.Add(guestIdCookie);
            }
            return _guestId.Value;
        }
        protected void SetAuthCookie(long guestId, string authData, bool rememberMe) {
            var expirationDate = rememberMe ? DateTime.Now.AddYears(1) : DateTime.MinValue;
            var authCookie = Request.Cookies[AuthCookieName];
            if (authCookie != null) {
                authCookie.Value = authData;
                authCookie.Expires = expirationDate;
            } else {
                Response.Cookies.Add(new HttpCookie(AuthCookieName, authData) {
                    Expires = expirationDate
                });

            }
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
        protected override bool DisableAsyncSupport {
            get { return true; }
        }

        protected override void ExecuteCore() {
            SetGuestIdCookie();
            base.ExecuteCore();
        }
    }
}