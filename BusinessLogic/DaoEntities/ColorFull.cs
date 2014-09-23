using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class ColorFull : AbstractEntity<ColorFull> {
        public ColorFull(string tableName) : base(tableName) {}

        public ColorFull() : base("ColorFull") { }

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof(Int32))]
            Id = 0,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof(Int32))]
            ColorSimpleId = 1,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Code = 2,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Name = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ColorSimpleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public ColorFullTransportType ToTransport() {
            return new ColorFullTransportType {
                Id = Id,
                Code = Code,
                ColorSimpleId = ColorSimpleId,
                Name = Name,
            };
        }
    }
}