using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class FormWithColor : AbstractEntity<FormWithColor> {
        public FormWithColor(string tableName) : base(tableName) {}
        public FormWithColor() : base("FormWithColor") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            FormId,
            [DbType(typeof (Int32))]
            ColorId,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof(string))]
            Image,
        }

        public int Id { get; set; }
        public int FormId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public FormWithColorTransportType ToTransport() {
            return new FormWithColorTransportType {
                Id = Id,
                Name = Name,
                FormId = FormId,
                ColorId = ColorId,
                Image = Image
            };
        }
    }
}