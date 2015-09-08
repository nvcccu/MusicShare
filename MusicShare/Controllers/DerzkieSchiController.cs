using System.Web.Mvc;
using Core.TransportTypes;
using MusicShareWeb.Models.DerzkieSchi;

namespace MusicShareWeb.Controllers {
    public class DerzkieSchiController : BaseController {
        [HttpGet]
        public ActionResult AddProduct() {
            if(CurrentUser == null || !BaseModel.IsDerzkiy(CurrentUser.Id)) {
                return View("NotEnoughDerzkiy", BaseModel);
            }
            return View("AddProduct", new ProductsModel(BaseModel));
        }
        [HttpGet]
        public ActionResult ChangeProduct(int? id) {
            if(CurrentUser == null || !BaseModel.IsDerzkiy(CurrentUser.Id)) {
                return View("NotEnoughDerzkiy", BaseModel);
            }
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
        [HttpGet]
        public ActionResult LessonOverview() {
            if(CurrentUser == null || !BaseModel.IsDerzkiy(CurrentUser.Id)) {
                return View("NotEnoughDerzkiy", BaseModel);
            }
            return View("LessonOverview", new LessonOverviewModel(BaseModel));
        }
        [HttpGet]
        public ActionResult Lesson(int? id) {
            if(CurrentUser == null || !BaseModel.IsDerzkiy(CurrentUser.Id)) {
                return View("NotEnoughDerzkiy", BaseModel);
            }
            return View("AdminLesson", id.HasValue ? new AdminLessonModel(id.Value, BaseModel) : new AdminLessonModel(BaseModel));
        }
        [HttpPost]
        public ActionResult CreateLesson(LessonDto lesson, string comment) {
            return new JsonResult {
                Data = new {
                    success = true,
                    redirectUrl = Url.Action("Lesson", "DerzkieSchi", new {id = new AdminLessonModel().CreateLesson(lesson, CurrentUser.Id, comment)})
                }
            };
        }
        [HttpPost]
        public JsonResult UpdateLesson(LessonDto lesson, string  comment) {
            return new JsonResult {
                Data = new {
                    success = new AdminLessonModel().UpdateLesson(lesson, CurrentUser.Id, comment)
                }
            };
        }
//        [HttpGet]
//        public ActionResult Exercise(int? id) {
//            return View("AdminExercise", id.HasValue ? new AdminExerciseModel(id.Value, BaseModel) : new AdminExerciseModel(BaseModel));
//        }
//        [HttpPost]
//        public ActionResult CreateExercise(ExerciseDto exercise) {
//            return new JsonResult {
//                Data = new {
//                    success = true,
//                    redirectUrl = Url.Action("Exercise", "DerzkieSchi", new {id = new AdminExerciseModel().CreateExercise(exercise)})
//                }
//            };
//        }
//        [HttpPost]
//        public JsonResult UpdateExercise(ExerciseDto exercise) {
//            return new JsonResult {
//                Data = new {
//                    success = new AdminExerciseModel().UpdateExercise(exercise)
//                }
//            };
//        }
    }
}