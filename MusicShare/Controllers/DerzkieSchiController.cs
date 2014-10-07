using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Guitars() {
            return View("Guitars", new GuitarsModel());
        }

        [HttpPost]
        public JsonResult SaveGuitarSummary(GuitarSummaryTransportType guitarSummary) {
            return new JsonResult {
                Data = ServiceManager<IBusinessLogic>.Instance.Service.SaveGuitarSummary(guitarSummary)
            };
        }
    }
}