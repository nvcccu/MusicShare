using System.Web.Mvc;
using MusicShareWeb.Models.Auth;

namespace MusicShareWeb.Controllers {
    public class AuthController: BaseController {
        [HttpPost]
        public ActionResult SignUp(EmailAuthModel auth) {
//            return RedirectToAction("Index", new {q = question.CreateNewQuestion()});
            return new EmptyResult();
        }
        [HttpPost]
        public ActionResult SignIn(EmailAuthModel auth) {
//            return RedirectToAction("Index", new {q = question.CreateNewQuestion()});
            return new EmptyResult();
        }
    }
}