using System.Web.Mvc;
using CommonUtils.PasswordHelper;
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
        public ActionResult SignInViaEmail(EmailAuthModel auth) {
            var accountId = auth.SignInViaEmail();
            if (accountId.HasValue && !Id.HasValue) {
                SetAuthCookie(0L, PasswordHelper.EncryptInt(accountId.Value), auth.RememberMe);
                return RedirectToAction("Index", "Designer");
            } else {
                return new EmptyResult();
            }
        }
    }
}