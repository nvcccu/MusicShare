using System.Web.Mvc;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class ArticleController : BaseController {
        public ActionResult Index() {
            return View("Index");
        }
        public ActionResult New() {
            return View("New", new BaseModel(CurrentUser));
        }
    }
}