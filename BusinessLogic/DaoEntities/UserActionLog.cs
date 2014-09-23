﻿using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class UserActionLog : AbstractEntity<UserActionLog> {
        public UserActionLog(string tableName) : base(tableName) {}

        public UserActionLog() : base("UserActionLog") { }

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] GuestId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] ActionId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] Target,
        }

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// guestId совершившего действие
        /// </summary>
        public long GuestId { get; set; }

        /// <summary>
        /// совершенное действие
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// дополнительный параметр. куда именно нажал, что именно выбрал и т. п.
        /// </summary>
        public long? Target { get; set; }

        public UserActionLogTransportType ToTransport() {
            return new UserActionLogTransportType {
                Id = Id,
                GuestId = GuestId,
                ActionId = ActionId,
                Target = Target
            };
        }
    }
}