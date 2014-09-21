using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Color : AbstractEntity<Color> {
        public Color(string tableName) : base(tableName) {}

        public Color() : base("Color") {}

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
            Code = 1,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Name = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public ColorTransportType ToTransport() {
            return new ColorTransportType {
                Id = Id,
                Code = Code,
                Name = Name,
            };
        }
    }
}