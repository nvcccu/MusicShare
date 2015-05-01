using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Index() {
            return View("Index", BaseModel);
        }
    }
}