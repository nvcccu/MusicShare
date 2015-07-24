using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using MusicShareWeb.Models.Market;

namespace MusicShareWeb.Controllers {
    public class MarketController : BaseController {
        public ActionResult Index() {
            var model = new CategoryListModel(BaseModel);
            model.Categories = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductTypes();
            return View("Category", model);
        }
        public ActionResult Selecting(long categoryId) {
            return View("Selecting", new SelectingModel(BaseModel, categoryId));
        }
    }
}