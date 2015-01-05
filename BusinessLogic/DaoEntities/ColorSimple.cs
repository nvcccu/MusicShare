using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class ColorSimple : AbstractEntity<ColorSimple> {
        public ColorSimple(string tableName) : base(tableName) {}

        public ColorSimple() : base("ColorSimple") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            Image,
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ColorSimpleTransportType ToTransport() {
            return new ColorSimpleTransportType {
                Id = Id,
                Name = Name,
                Image = Image,
            };
        }
    }
}