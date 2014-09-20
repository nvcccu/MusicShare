using System;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils;

namespace MusicShareWeb.Controllers {
    public class CookieBaseController : Controller {
        private const string GuestIdCookieName = "GuestId";
        private long? _guestId;

        protected long GuestId {
            get { return _guestId ?? SetGuestIdCookie(); }
        }

        private long SetGuestIdCookie() {
            var guestIdCookie = Request.Cookies.Get(GuestIdCookieName);
            if (guestIdCookie != null) {
                _guestId = Convert.ToInt64(guestIdCookie.Value);
            } else {
                _guestId = ServiceManager<IBusinessLogic>.Instance.Service.GetNextGuestId(Request.UserAgent);
                guestIdCookie = new HttpCookie("GuestId", _guestId.ToString()) {
                    Expires = new DateTime(DateTime.Now.AddYears(5).Year, 1, 1)
                };
                Response.Cookies.Add(guestIdCookie);
            }
            return _guestId.Value;
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