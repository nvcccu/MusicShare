using System.Web.Mvc;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Index() {
            return View("Index", new BaseModel(CurrentUser));
        }
    }
}