using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class LessonController : BaseController {
        public ActionResult Index(int? id) {
            return View("Index", BaseModel);
        }
    }
}