﻿using System.Web.Mvc;
using MusicShareWeb.Models.Auth;

namespace MusicShareWeb.Controllers {
    public class AuthController : BaseController {
        [HttpPost]
        public ActionResult SignUp(EmailAuthModel auth) {
            if (auth.IsEmailFree()) {
                if (auth.IsGuestAlreadyHasAccount(GuestId)) {
                    RegenerateGuestId();
                }
                var newAccountId = auth.Register(GuestId);
                if (newAccountId.HasValue) {
                    SetAuthCookie(GuestId, newAccountId.Value, auth.RememberMe);
                    return new JsonResult {
                        Data = new {
                            Success = true,
                            Redirect = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/"
                        },
                    };
                }
            }
            return new JsonResult {
                Data = new {
                    Success = false,
                    Reason = "Email занят",
                },
            };
        }
        [HttpPost]
        public JsonResult SignInViaEmail(EmailAuthModel auth) {
            var account = auth.SignInViaEmail();
            if (account != null) {
                SetAuthCookie(account.GuestId, account.Id, auth.RememberMe);
                return new JsonResult {
                    Data = new {
                        Success = true,
                        Redirect = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/"
                    },
                };
            } 
            return new JsonResult {
                Data = new {
                    Success = false,
                    Reason = "Неверные email или пароль",
                },
            };
        }
        [HttpGet]
        public ActionResult SignOut() {
            DropAuthCookie();
            return RedirectToAction("Index", "Designer");
        }
    }
}