using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class Guitar : AbstractEntity<Guitar> {
        public Guitar(string tableName) : base(tableName) {}

        public Guitar() : base("ElectronicGuitar") { }

        public enum Fields {
            [DbType(typeof(Int64))]
            Id = 0,

            [DbType(typeof(string))]
            Brand = 1,

            [DbType(typeof(string))]
            Model = 2,

            [DbType(typeof(string))]
            Color = 3,

            [DbType(typeof(string))]
            Form = 4,

            [DbType(typeof(string))]
            Image = 15,

            [DbType(typeof(decimal))]
            Price = 16,

            [DbType(typeof(string))]
            Url = 17
        };

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        public GuitarTransportType ToTransport() {
            return new GuitarTransportType {
                Id = Id,
                Brand = Brand,
                Model = Model,
                Color = Color,
                Form = Form,
                Image = Image,
                Price = Price,
                Url = Url,
            };
        }
    }
}