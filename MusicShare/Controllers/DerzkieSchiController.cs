using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Index() {
            return View("Index", new BaseModel());
        }
        
        public ActionResult Guitars() {
            return View("Guitars", new GuitarsModel());
        }
        
        public ActionResult Models() {
            return View("Models", new GuitarsModel());
        }

        [HttpPost]
        public JsonResult SaveGuitarSummary(GuitarSummaryTransportType guitarSummary) {
            return new JsonResult {
                Data = ServiceManager<IBusinessLogic>.Instance.Service.SaveGuitarSummary(guitarSummary)
            };
        }

        [HttpPost]
        public JsonResult SaveNewGuitar(GuitarSummaryTransportType guitarSummary) {
            return new JsonResult {
                Data = ServiceManager<IBusinessLogic>.Instance.Service.SaveNewGuitar(guitarSummary)
            };
        }

        [HttpPost]
        public JsonResult UpdateGuitarModel(GuitarWithModelTransportType guitarModel) {
            return new JsonResult {
                Data = ServiceManager<IBusinessLogic>.Instance.Service.UpdateGuitarModel(guitarModel)
            };
        }

        [HttpPost]
        public JsonResult SaveNewGuitarModel(GuitarWithModelTransportType guitarModel) {
            return new JsonResult {
                Data = ServiceManager<IBusinessLogic>.Instance.Service.SaveNewGuitarModel(guitarModel)
            };
        }
    }
}