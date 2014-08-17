using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class PlacardController : Controller {
        //
        // GET: /Placard/
        public ActionResult Index() {
            return View("Index");
        }
    }
}