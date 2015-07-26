using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class Product : AbstractEntity<Product> {
        public Product(string tableName) : base(tableName) {}

        public Product() : base("Product") { }

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int64))]
            ProductTypeIdId,
            [DbType(typeof (String))]
            Name,
            [DbType(typeof (String))]
            ImageUrl,
            [DbType(typeof (Int32))]
            Price
        }

        public int Id { get; set; }
        public long ProductTypeIdId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }

        public ProductDto ToDto() {
            return new ProductDto {
                Id = Id,
                ProductTypeIdId = ProductTypeIdId,
                Name = Name,
                ImageUrl = ImageUrl,
                Price = Price
            };
        }
    }
}