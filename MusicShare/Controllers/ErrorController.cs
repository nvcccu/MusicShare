using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class ErrorController : BaseController {
        public ViewResult Index() {
            return View("Error404");
        }

        public ViewResult NotFound() {
            Response.StatusCode = 404; //you may want to set this to 200
            return View("Error404");
        }
    }
}