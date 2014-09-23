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
            Id,

            [DbType(typeof(Int32))]
            BrandId,

            [DbType(typeof(Int32))]
            FormId,

            [DbType(typeof(string))]
            Model,
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