using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class ForumController : Controller {
        //
        // GET: /Forum/
        public ActionResult Index() {
            return View("Index");
        }
    }
}