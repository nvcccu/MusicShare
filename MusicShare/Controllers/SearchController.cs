using System.Web.Mvc;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers
{
    public class SearchController : Controller {
        public ActionResult Search(SearchQueryModel model) {
            return View("Index", "MainPage");
        }
	}
}