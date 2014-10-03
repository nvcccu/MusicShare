using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class ForumController : Controller {
        public ActionResult Index() {
            return View("Index");
        }
    }
}