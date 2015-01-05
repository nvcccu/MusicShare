using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Brand : AbstractEntity<Brand> {
        public Brand(string tableName) : base(tableName) {}

        public Brand() : base("Brand") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            Logo,
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public BrandTransportType ToTransport() {
            return new BrandTransportType {
                Id = Id,
                Name = Name,
                Logo = Logo
            };
        }
    }
}