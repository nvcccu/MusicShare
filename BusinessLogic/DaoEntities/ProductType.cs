using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class ProductType : AbstractEntity<ProductType> {
        public ProductType(string tableName) : base(tableName) {}

        public ProductType() : base("ProductType") { }

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (String))]
            Name
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ProductTypeDto ToDto() {
            return new ProductTypeDto {
                Id = Id,
                Name = Name,
            };
        }
    }
}