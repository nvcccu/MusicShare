using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IUserProvider {
        long GetNextGuestId(string userAgent);
        bool IsEmailFree(string email);
        bool IsNickNameFree(string nickName);
        int? RegisterViaEmail(long guestId, string email, string password, string nickName);
        AccountDto GetUserByEmail(string email);
        bool Login(AuthTransportType auth);
        AccountDto GetUser(long guestId);
        AccountDto GetUserById(long id);
        bool IsGuestAlreadyHasAccount(long guestId);
    }
}
