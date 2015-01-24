using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class DesignerImage : AbstractEntity<DesignerImage> {
        public DesignerImage(string tableName) : base(tableName) {}

        public DesignerImage() : base("DesignerImage") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Url
        }

        public int Id { get; set; }
        public string Url { get; set; }

        public DesignerImageDto ToDto() {
            return new DesignerImageDto {
                Id = Id,
                Url = Url
            };
        }
    }
}