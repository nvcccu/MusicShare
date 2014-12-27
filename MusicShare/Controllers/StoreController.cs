using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using MusicShareWeb.Models.Store;

namespace MusicShareWeb.Controllers {
    public class StoreController : BaseController {
        public ActionResult Index() {
            return View("Index", new CategoriesModel(ServiceManager<IBusinessLogic>.Instance.Service.GetAllOfferCategories()));
        }

        public ActionResult Category(long id) {
            return View("Category", new CategoriesModel(ServiceManager<IBusinessLogic>.Instance.Service.GetAllOfferCategories(), id));
        }

//        public ActionResult Offer(long id) {
//            return View("Offer", new OfferModel(ServiceManager<IBusinessLogic>.Instance.Service.GetAllOfferCategories(), id));
//        }
    }
}