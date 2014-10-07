using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class GuitarWithModel : AbstractEntity<GuitarWithModel> {
        public GuitarWithModel(string tableName) : base(tableName) {}

        public GuitarWithModel() : base("GuitarWithModel") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] GuitarId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Model,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int GuitarId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        public GuitarWithModelTransportType ToTransport() {
            return new GuitarWithModelTransportType {
                Id = Id,
                GuitarId = GuitarId,
                Model = Model
            };
        }
    }
}