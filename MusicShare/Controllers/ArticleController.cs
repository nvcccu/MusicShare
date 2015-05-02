using System.Web.Mvc;
using MusicShareWeb.Models.Article;

namespace MusicShareWeb.Controllers {
    public class ArticleController : BaseController {
        public ActionResult Index(int? id) {
            return id.HasValue
                ? View("Article", new ArticleModel(BaseModel, id.Value))
                : View("Index", BaseModel);
        }
        [HttpGet]
        public ActionResult New() {
            return View("New", BaseModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(ArticlePostModel articleModel) {
            return RedirectToAction("Index", new {id = articleModel.Save(CurrentUser.Id)});
        }
    }
}