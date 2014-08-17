using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class ArticleController : BaseController {
        public ActionResult Index() {
            return View("Index");
        }
    }
}