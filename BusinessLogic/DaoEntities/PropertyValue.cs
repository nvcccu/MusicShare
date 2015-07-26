using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class PropertyValue : AbstractEntity<PropertyValue> {
        public PropertyValue(string tableName) : base(tableName) {}

        public PropertyValue() : base("PropertyValue") { }

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (String))]
            Name,
            [DbType(typeof (Int64))]
            PropertyId
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long PropertyId { get; set; }

        public PropertyValueDto ToDto() {
            return new PropertyValueDto {
                Id = Id,
                Name = Name,
                PropertyId = PropertyId
            };
        }
    }
}