using System.Web.Mvc;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        [HttpGet]
        public ActionResult AddProduct() {
            return View("AddProduct", new ProductsModel(BaseModel));
        }
        [HttpGet]
        public ActionResult ChangeProduct(int? id) {
            return id.HasValue 
                ? View("ChangeProduct", new ProductsModel(BaseModel))
                : View("SelectProduct", new ProductsModel(BaseModel));
        }
        [HttpPost]
        public JsonResult GetFilteredProduct(FilterProductModel filterProductModel) {
            return new JsonResult {
                Data = new {
                    products = filterProductModel.GetFilteredProduct()
                }
            };
        }
        [HttpPost]
        public ActionResult SaveProduct(NewProductsModel newProductsModel) {
            newProductsModel.SaveNewProduct();
            return null;
        }
    }
}