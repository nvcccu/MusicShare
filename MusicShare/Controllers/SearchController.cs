using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
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
            var sr = ServiceManager<IBusinessLogic>.Instance.Service.Search(gtp.BrandId, gtp.FormId, 1);
            var dataModel = new SearchResultModel(sr);
            return View("Index", dataModel);
        }

        [HttpGet]
        public JsonResult GetSampleGuitars(int? brandId, int? formId, int? simpleColorIdColor) {
            var sample = ServiceManager<IBusinessLogic>.Instance.Service.GetSampleGuitars(brandId, formId, simpleColorIdColor);
            return new JsonResult {
                Data = sample,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
    }
}