using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Guitar : AbstractEntity<Guitar> {
        public Guitar(string tableName) : base(tableName) {}

        public Guitar() : base("Guitar") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id = 0,

            [DbType(typeof(Int32))]
            BrandId = 1,

            [DbType(typeof(Int32))]
            FormId = 3,

            [DbType(typeof(string))]
            Model = 4,
        };

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        public GuitarTransportType ToTransport() {
            return new GuitarTransportType {
                Id = Id,
                BrandId = BrandId,
                FormId = FormId,
                Model = Model,
            };
        }
    }
}