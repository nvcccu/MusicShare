using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class ParameterValue : AbstractEntity<ParameterValue> {
        public ParameterValue(string tableName) : base(tableName) {}

        public ParameterValue() : base("ParameterValue") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ParameterId,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            ImagePreviewUrl
        }

        public int Id { get; set; }
        public int ParameterId { get; set; }
        public string Name { get; set; }
        public string ImagePreviewUrl { get; set; }

        public ParameterValueDto ToDto() {
            return new ParameterValueDto {
                Id = Id,
                ParameterId = ParameterId,
                Name = Name,
                ImagePreviewUrl = ImagePreviewUrl
            };
        }
    }
}