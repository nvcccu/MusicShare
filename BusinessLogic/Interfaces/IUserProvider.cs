﻿using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IUserProvider {
        long GetNextGuestId(string userAgent);
        bool IsEmailFree(string email);
        int? RegisterViaEmail(long guestId, string email, string password);
        bool Login(AuthTransportType auth);
        AccountDto GetUser(long guestId);
    }
}
