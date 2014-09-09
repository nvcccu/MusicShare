using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Guitar : AbstractEntity<Guitar> {
        public Guitar(string tableName) : base(tableName) {}

        public Guitar() : base("Guitar") { }

        public enum Fields {
            [DbType(typeof(Int64))]
            Id = 0,

            [DbType(typeof(short))]
            Brand = 1,

            [DbType(typeof(short))]
            Color = 2,

            [DbType(typeof(short))]
            Form = 3,

            [DbType(typeof(string))]
            Image = 4,
        };

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short Brand { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public short Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short Form { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Image { get; set; }

        public GuitarTransportType ToTransport() {
            return new GuitarTransportType {
                Id = Id,
                Brand = Brand,
                Color = Color,
                Form = Form,
                Image = Image,
            };
        }
    }
}