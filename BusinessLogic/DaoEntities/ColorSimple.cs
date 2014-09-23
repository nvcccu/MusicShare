using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class ColorSimple : AbstractEntity<ColorSimple> {
        public ColorSimple(string tableName) : base(tableName) {}

        public ColorSimple() : base("ColorSimple") { }

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof(Int32))]
            Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Name,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public ColorSimpleTransportType ToTransport() {
            return new ColorSimpleTransportType {
                Id = Id,
                Name = Name,
            };
        }
    }
}