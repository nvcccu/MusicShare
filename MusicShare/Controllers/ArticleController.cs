using System.Web.Mvc;
using MusicShareWeb.Models.Article;

namespace MusicShareWeb.Controllers {
    public class ArticleController : BaseController {
        public ActionResult Index() {
            return View("Index", BaseModel);
        }
        [HttpGet]
        public ActionResult New() {
            return View("New", BaseModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(ArticlePostModel articleModel) {
            articleModel.Save(CurrentUser.Id);
            return RedirectToAction("Index", BaseModel);
        }
    }
}