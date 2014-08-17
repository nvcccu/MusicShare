using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class SearchController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            return View("Index");
        }
        public ActionResult Index1() {
            return View("Index1");
        }

        [HttpPost]
        public ActionResult Search(string brand = null, string form = null, string model = null, string manufacturer = null, string color = null, int? priceFrom = null, int? priceTo = null) {
            var sr = ServiceManager<IBusinessLogic>.Instance.Service.Search(brand, model, color);
            var dataModel = new SearchResultModel(sr);
            return View("Index", dataModel);
        }
    }
}