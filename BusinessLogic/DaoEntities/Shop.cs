using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities
{
    public class Shop : AbstractEntity<Shop> {
        public Shop(string tableName) : base(tableName) {}

        public Shop() : base("Shop") { }

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))]
            Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Name,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Email,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Phone,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        public ShopTransportType ToTransport() {
            return new ShopTransportType {
                Id = Id,
                Name = Name,
                Email = Email,
                Phone = Phone
            };
        }
    }
}