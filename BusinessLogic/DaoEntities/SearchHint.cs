using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class SearchHint : AbstractEntity<SearchHint> {
        public SearchHint(string tableName) : base(tableName) {}

        public SearchHint() : base("SearchHint") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))]
            Id = 0,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))]
            SearchStepId = 1,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Text = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SearchStepId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        public SearchHintTransportType ToTransport() {
            return new SearchHintTransportType {
                Id = Id,
                SearchStepId = SearchStepId,
                Text = Text
            };
        }
    }
}