using System.Web.Mvc;
using MusicShareWeb.Models.Auth;

namespace MusicShareWeb.Controllers {
    public class AuthController : BaseController {
        [HttpPost]
        public ActionResult SignUp(EmailAuthModel auth) {
            if (auth.IsEmailFree()) {
                var result = auth.Register(GuestId);
                if (result != null) {
                    SetAuthCookie(GuestId, result, auth.RememberMe);
                    return new JsonResult();
                } else {
                    return new EmptyResult();
                }
            }
            return new EmptyResult();
        }
        [HttpPost]
        public ActionResult SignIn(EmailAuthModel auth) {
//            return RedirectToAction("Index", new {q = question.CreateNewQuestion()});
            return new EmptyResult();
        }
    }
}