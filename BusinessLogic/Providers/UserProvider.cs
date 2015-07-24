using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using CommonUtils.PasswordHelper;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class UserProvider : IUserProvider {
        public static List<string> BotUserAgent = new List<string>() {
            "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)",
            "Googlebot/2.1 (+http://www.google.com/bot.html)",
            "Googlebot-News",
            "Googlebot-Image/1.0",
            "Googlebot-Video/1.0",
            "Googlebot-Mobile/2.1; +http://www.google.com/bot.html)",
            "(compatible; Mediapartners-Google/2.1; +http://www.google.com/bot.html)",
            "Mediapartners-Google",
            "AdsBot-Google (+http://www.google.com/adsbot.html)",
            "Mozilla/5.0 (compatible; YandexBot/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexImages/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexVideo/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexMedia/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexBlogs/0.99; robot; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexFavicons/1.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexWebmaster/2.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexPagechecker/1.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexImageResizer/2.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexDirect/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexDirect/2.0; Dyatel; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexMetrika/2.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexNews/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexNewslinks; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexCatalog/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexAntivirus/2.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexZakladki/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexSitelinks; Dyatel; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; YandexVertis/3.0; +http://yandex.com/bots)",
            "Mozilla/5.0 (compatible; Mail.RU_Bot/Fast/2.0)",
            "StackRambler/2.0 (MSIE incompatible)",
            "StackRambler/2.0",
            "Mozilla/5.0 (compatible; Yahoo! Slurp; http://help.yahoo.com/help/us/ysearch/slurp)",
            "Mozilla/5.0 (compatible; Yahoo! Slurp/3.0; http://help.yahoo.com/help/us/ysearch/slurp)",
            "msnbot/1.1 (+http://search.msn.com/msnbot.htm)",
            "msnbot-media/1.0 (+http://search.msn.com/msnbot.htm)",
            "msnbot-media/1.1 (+http://search.msn.com/msnbot.htm)",
            "msnbot-news (+http://search.msn.com/msnbot.htm)",
            "Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)",
        };

        public long GetNextGuestId(string userAgent) {
            if (BotUserAgent.Any(ua => ua == userAgent)) {
                return -1;
            }
            var lastGuestId = new Guest()
                .Select()
                .OrderBy(Guest.Fields.GuestId, OrderType.Desc)
                .GetData()
                .First().GuestId;
            new Guest {
                GuestId = ++lastGuestId,
                UserAgent = userAgent
            }.Insert();
            return lastGuestId;
        }
        public bool IsEmailFree(string email) {
            return !new Account().Select().Where(Account.Fields.Email, PredicateCondition.Equal, email).GetData().Any();
        }
        public int? RegisterViaEmail(long guestId, string email, string password) {
            int? accountId = null;
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password)) {
                var salt = PasswordHelper.GenerateSalt();
                var hashedPassword = PasswordHelper.HashPassword(password, salt);
                accountId = Convert.ToInt32(new Account {
                    Email = email,
                    Password = hashedPassword,
                    Salt = salt,
                    GuestId = guestId,
                    DateRegistered = DateTime.UtcNow
                }.Insert());
                new Account()
                    .Update()
                    .Set(Account.Fields.NickName, "User" + accountId)
                    .Where(Account.Fields.Id, PredicateCondition.Equal, accountId.Value)
                    .ExecuteScalar();
            }
            return accountId;
        }
        public bool Login(AuthTransportType auth) {
            if (!String.IsNullOrEmpty(auth.Email) && !String.IsNullOrEmpty(auth.Password)) {
                var account = new Account()
                    .Where(Account.Fields.Email, PredicateCondition.Equal, auth.Email)
                    .GetData()
                    .First();
                return PasswordHelper.CheckPasswordEqual(auth.Password, account.Salt, account.Password);
            }
            return false;
        }
        public AccountDto GetUser(long guestId) {
            return new Account()
                .Select()
                .Where(Account.Fields.GuestId, PredicateCondition.Equal, guestId)
                .GetData()
                .Single()
                .ToDto();
        }
        public AccountDto GetUserById(long id) {
            return new Account()
                .Select()
                .Where(Account.Fields.Id, PredicateCondition.Equal, id)
                .GetData()
                .Single()
                .ToDto();
        }
        public bool IsGuestAlreadyHasAccount(long guestId) {
            return new Account()
                .Select()
                .Where(Account.Fields.GuestId, PredicateCondition.Equal, guestId)
                .GetData()
                .Any();
        }
        public AccountDto GetUserByEmail(string email) {
            var account = new Account()
                .Select()
                .Where(Account.Fields.Email, PredicateCondition.Equal, email)
                .GetData()
                .SingleOrDefault();
            return account != null ? account.ToDto() : null;
        }
    }
}