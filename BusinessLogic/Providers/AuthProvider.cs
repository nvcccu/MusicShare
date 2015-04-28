using System;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using CommonUtils.PasswordHelper;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    internal class AuthProvider : IAuthProvider {
        public bool SignUp(AuthTransportType auth) {
            if (!String.IsNullOrEmpty(auth.Email) && !String.IsNullOrEmpty(auth.Password)) {
                var salt = PasswordHelper.GenerateSalt();
                var hashedPassword = PasswordHelper.HashPassword(auth.Password, salt);
                var accountId = Convert.ToInt64(new Account {
                    Email = auth.Email,
                    Password = hashedPassword,
                    Salt = salt,
                    GuestId = auth.GuestId,
                    DateRegistered = DateTime.UtcNow
                }.Insert());
                new Account().Update()
                    .Set(Account.Fields.NickName, "User" + accountId)
                    .Where(Account.Fields.Id, PredicateCondition.Equal, accountId)
                    .ExecuteScalar();
                return true;
            }
            return false;
        }
        public bool Login(AuthTransportType auth) {
            if (!String.IsNullOrEmpty(auth.Email) && !String.IsNullOrEmpty(auth.Password)) {
                var account = new Account()
                    .Where(Account.Fields.Email, PredicateCondition.Equal, auth.Email)
                    .GetData()
                    .First();
                var hashedPassword = PasswordHelper.HashPassword(auth.Password, account.Salt);
                return account.Password == hashedPassword;
            }
            return false;
        }
    }
}