using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Account : AbstractEntity<Account> {
        public Account(string tableName) : base(tableName) {}

        public Account() : base("Account") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int64))]
            GuestId,
            [DbType(typeof (String))]
            NickName,
            [DbType(typeof (String))]
            Name,
            [DbType(typeof (DateTime))]
            DateRegistered,
            [DbType(typeof (String))]
            Email,
            [DbType(typeof (String))]
            Salt,
            [DbType(typeof (String))]
            Password,
        }

        public int Id { get; set; }
        public long GuestId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        public AccountDto ToDto() {
            return new AccountDto {
                Id = Id,
                GuestId = GuestId,
                NickName = NickName,
                Name = Name,
                DateRegistered = DateRegistered,
                Email = Email,
                Salt = Salt,
                Password = Password
            };
        }
    }
}