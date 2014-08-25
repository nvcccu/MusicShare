using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils;
using Core.TransportTypes;
using MusicShareWeb.Models;

namespace MusicShareWeb.Controllers {
    public class SearchController : BaseController {
        [HttpGet]
        public ActionResult Index() {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Search(GuitarTransportType gtp) {
            var sr = ServiceManager<IBusinessLogic>.Instance.Service.Search(gtp.Brand, gtp.Model, gtp.Color);
            var dataModel = new SearchResultModel(sr);
            return View("Index", dataModel);
        }
    }
}