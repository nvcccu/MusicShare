using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class DerzkiyAccount : AbstractEntity<DerzkiyAccount> {
        public DerzkiyAccount(string tableName) : base(tableName) {}

        public DerzkiyAccount() : base("DerzkiyAccount") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id
        }

        public int Id { get; set; }

        public DerzkiyAccountDto ToDto() {
            return new DerzkiyAccountDto {
                Id = Id
            };
        }
    }
}