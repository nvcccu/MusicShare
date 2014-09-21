using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.Enums;

namespace BusinessLogic.Providers {
    public class LogProvider : ILogProvider {
        /// <summary>
        /// делает запись действия в базу
        /// </summary>
        /// <param name="guestId"></param>
        /// <param name="actionId"></param>
        /// <param name="target"></param>
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            new UserActionLog {
                GuestId = guestId,
                ActionId = (int)actionId,
                Target = target
            }.Save();
        }
    }
}