using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class OfferCategory : AbstractEntity<OfferCategory> {
        public OfferCategory(string tableName) : base(tableName) {}

        public OfferCategory() : base("OfferCategory") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] ParentId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Name,
        }

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public OfferCategoryTransportType ToTransport() {
            return new OfferCategoryTransportType {
                Id = Id,
                ParentId = ParentId,
                Name = Name
            };
        }
    }
}