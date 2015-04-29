using System;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Models.User {
    public class Account {
        public int Id { get; set; }
        public long GuestId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsAuthorized { get; set; }

        public Account(long guestId) {
            var accountDto = ServiceManager<IBusinessLogic>.Instance.Service.GetUser(guestId);
            if (accountDto != null) {
                Id = accountDto.Id;
                GuestId = accountDto.GuestId;
                NickName = accountDto.NickName;
                Name = accountDto.Name;
                DateRegistered = accountDto.DateRegistered;
                IsAuthorized = true;
            } else {
                GuestId = guestId;
                IsAuthorized = false;
            }
        }
    }
}