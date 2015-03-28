using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class AskController : Controller {
        public ActionResult Index() {
            return View("Index");
        }
    }
}