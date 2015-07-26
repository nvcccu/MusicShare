using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class Property : AbstractEntity<Property> {
        public Property(string tableName) : base(tableName) {}

        public Property() : base("Property") { }

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (String))]
            Name,
            [DbType(typeof (Int64))]
            ProductTypeId
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long ProductTypeId { get; set; }

        public PropertyDto ToDto() {
            return new PropertyDto {
                Id = Id,
                Name = Name,
                ProductTypeId = ProductTypeId
            };
        }
    }
}