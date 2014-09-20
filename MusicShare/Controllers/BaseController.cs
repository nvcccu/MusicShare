using System.Web.Mvc;
using BusinessLogic;
using CommonUtils;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class BaseController : CookieBaseController{
        protected BaseModel BaseModel;

        public BaseController() {}
    }
}