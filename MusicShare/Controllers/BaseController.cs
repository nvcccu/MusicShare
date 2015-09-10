using System;
using System.Web.Mvc;
using MusicShareWeb.Models;
using MusicShareWeb.Models.User;
using SquishIt.Framework;
using SquishIt.Mvc;

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
                        _currentUser = new Account(GuestId, Id);
                    }
                }
                return _currentUser;
            }
        }
        public ActionResult Js(string identifier) {
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.JavaScript().RenderCached(identifier), "text/javascript");
        }
        public ActionResult Css(string identifier) {
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.Css().RenderCached(identifier), "text/css");
        }
    }

    public class AssetsController : SquishItController {
       
    }
}