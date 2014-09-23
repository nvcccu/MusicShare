using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Brand : AbstractEntity<Brand> {
        public Brand(string tableName) : base(tableName) {}

        public Brand() : base("Brand") {}

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
            Logo,
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
        public string Logo { get; set; }

        public BrandTransportType ToTransport() {
            return new BrandTransportType {
                Id = Id,
                Name = Name,
                Logo = Logo
            };
        }
    }
}