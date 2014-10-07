using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class GuitarWithColor : AbstractEntity<GuitarWithColor> {
        public GuitarWithColor(string tableName) : base(tableName) {}

        public GuitarWithColor() : base("GuitarWithColor") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] GuitarWithModelId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] ColorFullId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (String))] PhotoUrl,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Boolean))] IsGreatQualityPhoto,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int GuitarWithModelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ColorFullId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGreatQualityPhoto { get; set; }

        public GuitarWithColorTransportType ToTransport() {
            return new GuitarWithColorTransportType {
                Id = Id,
                GuitarWithModelId = GuitarWithModelId,
                ColorId = ColorFullId,
                PhotoUrl = PhotoUrl,
                IsGreatQualityPhoto = IsGreatQualityPhoto
            };
        }
    }
}