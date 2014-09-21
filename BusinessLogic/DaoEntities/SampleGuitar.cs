using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class SampleGuitar : AbstractEntity<SampleGuitar> {
        public SampleGuitar(string tableName) : base(tableName) {}

        public SampleGuitar() : base("SampleGuitar") {}

        public enum Fields {
            [DbType(typeof (Int64))]
            Id = 0,

            [DbType(typeof (short))]
            Brand = 1,

            [DbType(typeof (short))]
            Color = 2,

            [DbType(typeof (short))]
            Form = 3,

            [DbType(typeof (string))]
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