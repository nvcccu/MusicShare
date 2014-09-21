using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Guest : AbstractEntity<Guest> {
        public Guest(string tableName) : base(tableName) {}

        public Guest() : base("Guest") {}

        public enum Fields {
            /// <summary>
            /// уникальный идентификатор гостя
            /// </summary>
            [DbType(typeof (Int64))]
            GuestId = 0,

            /// <summary>
            /// его useragent
            /// </summary>
            [DbType(typeof (string))]
            UserAgent = 1,
        }

        /// <summary>
        /// уникальный идентификатор гостя
        /// </summary>
        public long GuestId { get; set; }

        /// <summary>
        /// его useragent
        /// </summary>
        public string UserAgent { get; set; }

        public GuestTransportType ToTransport() {
            return new GuestTransportType {
                GuestId = GuestId,
                UserAgent = UserAgent
            };
        }
    }
}