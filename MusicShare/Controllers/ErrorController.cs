using System.Web.Mvc;

namespace MusicShareWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("Error404");
        }
    }
}
