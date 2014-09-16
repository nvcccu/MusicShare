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
            [DbType(typeof (Int16))]
            Id = 0,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Name = 1,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (long))]
            Code = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Code { get; set; }

        public BrandTransportType ToTransport() {
            return new BrandTransportType {
                Id = Id,
                Name = Name,
                Code = Code
            };
        }
    }
}