using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class MyController : BaseController {
        [HttpGet]
        public ActionResult Account() {
            return View("Profile");
        }
    }
}