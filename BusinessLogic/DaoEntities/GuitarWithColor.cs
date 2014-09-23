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
            [DbType(typeof (Int32))] GuitarId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] ColorId,

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
        public int GuitarId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ColorId { get; set; }

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
                GuitarId = GuitarId,
                ColorId = ColorId,
                PhotoUrl = PhotoUrl,
                IsGreatQualityPhoto = IsGreatQualityPhoto
            };
        }
    }
}