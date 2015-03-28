using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class News : AbstractEntity<News> {
        public News(string tableName) : base(tableName) {}

        public News() : base("News") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Title,
            [DbType(typeof (string))]
            Text,
            [DbType(typeof (string))]
            Image,
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        public NewsDto ToDto() {
            return new NewsDto {
                Id = Id,
                Title = Title,
                Text = Text,
                Image = Image
            };
        }
    }
}
