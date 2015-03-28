using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class UserActionLog : AbstractEntity<UserActionLog> {
        public UserActionLog(string tableName) : base(tableName) {}

        public UserActionLog() : base("UserActionLog") { }

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (Int64))]
            GuestId,
            [DbType(typeof (Int32))]
            ActionId,
            [DbType(typeof (Int64))]
            Target
        }

        public long Id { get; set; }
        public long GuestId { get; set; }
        public int ActionId { get; set; }
        public long? Target { get; set; }

        public UserActionLogDto ToDto() {
            return new UserActionLogDto {
                Id = Id,
                GuestId = GuestId,
                ActionId = ActionId,
                Target = Target
            };
        }
    }
}