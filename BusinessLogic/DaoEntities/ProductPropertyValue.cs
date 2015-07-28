using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class ProductPropertyValue : AbstractEntity<ProductPropertyValue> {
        public ProductPropertyValue(string tableName) : base(tableName) {}

        public ProductPropertyValue() : base("ProductPropertyValue") { }

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ProductId,
            [DbType(typeof (Int32))]
            PropertyId,
            [DbType(typeof (Int32))]
            PropertyValueId
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public int? PropertyValueId { get; set; }

        public ProductPropertyValueDto ToDto() {
            return new ProductPropertyValueDto {
                Id = Id,
                ProductId = ProductId,
                PropertyId = PropertyId,
                PropertyValueId = PropertyValueId
            };
        }
    }
}