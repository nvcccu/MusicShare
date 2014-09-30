using System.Web.Mvc;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Guitars() {
            return View("Guitars", new GuitarsModel());
        }
    }
}