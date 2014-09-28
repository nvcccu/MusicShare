using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Guitars() {
            return View("Guitars");
        }
    }
}