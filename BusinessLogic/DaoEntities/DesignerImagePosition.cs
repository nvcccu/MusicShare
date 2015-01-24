using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class DesignerImagePosition : AbstractEntity<DesignerImagePosition> {
        public DesignerImagePosition(string tableName) : base(tableName) {}

        public DesignerImagePosition() : base("DesignerImagePosition") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ImageId,
            [DbType(typeof (string))]
            Parameters,
            [DbType(typeof (Int32))]
            X,
            [DbType(typeof (Int32))]
            Y
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public string Parameters { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public DesignerImagePositionDto ToDto() {
            return new DesignerImagePositionDto {
                Id = Id,
                ImageId = ImageId,
                Parameters = Parameters,
                X = X,
                Y = Y
            };
        }
    }
}