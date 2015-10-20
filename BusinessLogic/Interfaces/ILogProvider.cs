using Core.Enums;

namespace BusinessLogic.Interfaces {
    public interface ILogProvider {
        void AddUserAction(long guestId, ActionId actionId, long? target = null);
        void TestLog();
    }
}