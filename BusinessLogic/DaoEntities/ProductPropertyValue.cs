using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class ProductPropertyValue : AbstractEntity<ProductPropertyValue> {
        public ProductPropertyValue(string tableName) : base(tableName) {}

        public ProductPropertyValue() : base("ProductPropertyValue") { }

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (Int64))]
            ProductId,
            [DbType(typeof (Int64))]
            PropertyId,
            [DbType(typeof (Int64))]
            PropertyValueId
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long PropertyId { get; set; }
        public long PropertyValueId { get; set; }

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