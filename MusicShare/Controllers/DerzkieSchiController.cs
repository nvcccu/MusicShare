using System.Web.Mvc;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        public ActionResult Index() {
            return View("Index", BaseModel);
        }
        public ActionResult Products() {
            return View("Products", new ProductsModel(BaseModel));
        }
        public JsonResult AddNewProduct() {
            return new JsonResult();
        }
    }
}