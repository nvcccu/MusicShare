using System.Web.Mvc;
using Core.TransportTypes;
using MusicShareWeb.Models.Ask;

namespace MusicShareWeb.Controllers {
    public class AskController : BaseController {
        [HttpGet]
        public ActionResult Index(long? q) {
            return q.HasValue
                ? View("Thread", new AskThreadModel(BaseModel, q.Value))
                : View("List", new QuestionListModel(BaseModel));
        }
        [HttpGet]
        public ActionResult New() {
            return View("New", new QuestionModel(BaseModel));
        }
        [HttpPost]
        public ActionResult New(QuestionDto question) {
            if (BaseModel.CurrentUser == null) {
                return RedirectToAction("New", new QuestionModel(BaseModel));
            }
            question.AccountId = BaseModel.CurrentUser.Id;
            var questionModel = new QuestionModel(BaseModel) {
                AccountId = BaseModel.CurrentUser.Id,
                Title = question.Title,
                Text = question.Text
            };
            return RedirectToAction("Index", new {q = questionModel.CreateNewQuestion()});
        }
    }
}