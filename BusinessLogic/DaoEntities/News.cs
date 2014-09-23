using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class News : AbstractEntity<News> {
        public News(string tableName) : base(tableName) {}

        public News() : base("News") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int32))]
            Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Title,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Text,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))]
            Image,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Image { get; set; }

        public NewsTransportType ToTransport() {
            return new NewsTransportType {
                Id = Id,
                Title = Title,
                Text = Text,
                Image = Image
            };
        }
    }
}
