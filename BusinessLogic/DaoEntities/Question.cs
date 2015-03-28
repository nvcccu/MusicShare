using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Question : AbstractEntity<Guest> {
        public Question(string tableName) : base(tableName) {}

        public Question() : base("Question") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,

            /// <summary>
            /// его useragent
            /// </summary>
            [DbType(typeof (string))]
            UserAgent,
        }

        /// <summary>
        /// уникальный идентификатор гостя
        /// </summary>
        public long GuestId { get; set; }

        /// <summary>
        /// его useragent
        /// </summary>
        public string UserAgent { get; set; }

        public GuestDto ToTransport() {
            return new GuestDto {
                GuestId = GuestId,
                UserAgent = UserAgent
            };
        }
    }
}