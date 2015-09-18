using System;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.Enums;

namespace BusinessLogic.Providers {
    public class LogProvider : ILogProvider {
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            new UserActionLog {
                GuestId = guestId,
                ActionId = (int)actionId,
                Target = target,
                Date = DateTime.Now
            }.Insert();
        }
    }
}