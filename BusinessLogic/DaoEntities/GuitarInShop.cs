using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class GuitarInShop : AbstractEntity<GuitarInShop> {
        public GuitarInShop(string tableName) : base(tableName) {}

        public GuitarInShop() : base("GuitarInShop") {}

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
            [DbType(typeof (Int32))] StoreId,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Boolean))] Available,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (int))] Price,
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
        public int StoreId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }

        public GuitarInShopTransportType ToTransport() {
            return new GuitarInShopTransportType {
                Id = Id,
                GuitarId = GuitarId,
                StoreId = StoreId,
                Available = Available,
                Price = Price
            };
        }
    }
}