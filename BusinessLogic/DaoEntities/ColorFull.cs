using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class ColorFull : AbstractEntity<ColorFull> {
        public ColorFull(string tableName) : base(tableName) {}

        public ColorFull() : base("ColorFull") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            ColorSimpleId,
            [DbType(typeof (string))]
            Code,
            [DbType(typeof (string))]
            Name,
        }

        public int Id { get; set; }
        public int ColorSimpleId { get; set; }
        public string Code { get; set; }
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