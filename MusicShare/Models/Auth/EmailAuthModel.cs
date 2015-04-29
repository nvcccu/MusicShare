using System;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Auth {
    public class EmailAuthModel{
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public int? Register(long guestId) {
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password)) {
                var registerResult = ServiceManager<IBusinessLogic>.Instance.Service.RegisterViaEmail(guestId, Email, Password);
                return registerResult;
            }
            return null;
        }
        public bool IsEmailFree() {
            return ServiceManager<IBusinessLogic>.Instance.Service.IsEmailFree(Email);
        }
        public AccountDto SignInViaEmail() {
            return ServiceManager<IBusinessLogic>.Instance.Service.GetUserByEmail(Email);
        }
    }
}