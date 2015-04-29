using System;
using BusinessLogic.Interfaces;
using CommonUtils.PasswordHelper;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Models.Auth {
    public class EmailAuthModel{
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string Register(long guestId) {
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password)) {
                var registerResult = RegisterViaEmail(guestId);
                if (registerResult.HasValue) {
                    return PasswordHelper.EncryptInt(registerResult.Value);
                }
            }
            return null;
        }
        public bool IsEmailFree() {
            return ServiceManager<IBusinessLogic>.Instance.Service.IsEmailFree(Email);
        }
        private int? RegisterViaEmail(long guestId) {
            return ServiceManager<IBusinessLogic>.Instance.Service.RegisterViaEmail(guestId, Email, Password);
        }
        public int? SignInViaEmail() {
            var account = ServiceManager<IBusinessLogic>.Instance.Service.GetUserByEmail(Email);
            return account != null ? account.Id : (int?)null;
        }
    }
}