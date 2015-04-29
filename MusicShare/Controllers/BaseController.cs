using System;
using System.Web;
using System.Web.Security;
using MusicShareWeb.Models;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Controllers {
    public class BaseController : CookieBaseController {
        private BaseModel _baseModel;
        protected BaseModel BaseModel {
            get {
                if (_baseModel == null) {
                    _baseModel = new BaseModel(CurrentUser);
                }
                return _baseModel;
            }
        }

        private Account _currentUser;
        public Account CurrentUser {
            get {
                if (_currentUser == null) {
                    object cookie = HttpContext.Request.Cookies[AuthCookieName] != null ? HttpContext.Request.Cookies[AuthCookieName].Value : null;
                    if (cookie != null && !string.IsNullOrEmpty(cookie.ToString())) {
                        _currentUser = new Account(GuestId);
                    }
                }
                return _currentUser;
            }
        }
    }
}