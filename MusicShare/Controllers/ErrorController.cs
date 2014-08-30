using System.Web.Mvc;

namespace MusicShareWeb.Controllers {
    public class ErrorController : BaseController {
        /// <summary>
        /// 404
        /// </summary>
        /// <returns></returns>
        public ViewResult NotFound() {
            Response.StatusCode = 404; 
            return View("Error404");
        }
        
        /// <summary>
        /// 500
        /// </summary>
        /// <returns></returns>
        public ViewResult InternalError() {
            Response.StatusCode = 500; 
            return View("Error500");
        }
    }
}