using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Guest : AbstractEntity<Guest> {
        public Guest(string tableName) : base(tableName) {}

        public Guest() : base("Guest") {}

        public enum Fields {
            [DbType(typeof (Int64))]
            GuestId,
            [DbType(typeof (string))]
            UserAgent
        }

        public long GuestId { get; set; }
        public string UserAgent { get; set; }

        public GuestDto ToDto() {
            return new GuestDto {
                GuestId = GuestId,
                UserAgent = UserAgent
            };
        }
    }
}