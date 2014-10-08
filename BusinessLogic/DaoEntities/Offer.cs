using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Offer : AbstractEntity<Offer> {
        public Offer(string tableName) : base(tableName) {}

        public Offer() : base("Offer") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Boolean))] Available,
            
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))] Price,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int64))] CategoryId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Picture,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (bool))] Store,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (bool))] Pickup,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (bool))] Delivery,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Name,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Description,
        }

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Available { get; set; }
            
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Store { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Pickup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Delivery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        public OfferTransportType ToTransport() {
            return new OfferTransportType {
                Id = Id,
                Available = Available,
                Price = Price,
                CategoryId = CategoryId,
                Picture = Picture,
                Store = Store,
                Pickup = Pickup,
                Delivery = Delivery,
                Name = Name,
                Description = Description
            };
        }
    }
}