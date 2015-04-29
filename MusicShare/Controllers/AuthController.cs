using System.Web.Mvc;
using MusicShareWeb.Models.Auth;

namespace MusicShareWeb.Controllers {
    public class AuthController : BaseController {
        [HttpPost]
        public ActionResult SignUp(EmailAuthModel auth) {
            if (auth.IsEmailFree()) {
                var newAccountId = auth.Register(GuestId);
                if (newAccountId.HasValue) {
                    SetAuthCookie(GuestId, newAccountId.Value, auth.RememberMe);
                    return new JsonResult();
                } else {
                    return new EmptyResult();
                }
            }
            return new EmptyResult();
        }
        [HttpPost]
        public ActionResult SignInViaEmail(EmailAuthModel auth) {
            var account = auth.SignInViaEmail();
            if (account != null) {
                SetAuthCookie(account.GuestId, account.Id, auth.RememberMe);
                return RedirectToAction("Index", "Designer");
            } else {
                return new EmptyResult();
            }
        }
    }
}