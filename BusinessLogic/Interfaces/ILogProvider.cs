using Core.Enums;

namespace BusinessLogic.Interfaces {
    public interface ILogProvider {
        /// <summary>
        /// делает запись действия в базу
        /// </summary>
        /// <param name="guestId"></param>
        /// <param name="actionId"></param>
        /// <param name="target"></param>
        void AddUserAction(long guestId, ActionId actionId, long? target = null);
    }
}