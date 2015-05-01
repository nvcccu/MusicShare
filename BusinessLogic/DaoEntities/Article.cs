using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Article : AbstractEntity<Article> {
        public Article(string tableName) : base(tableName) {}

        public Article() : base("Article") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            AuthorId,
            [DbType(typeof (String))]
            Title,
            [DbType(typeof (String))]
            Text,
            [DbType(typeof (DateTime))]
            DateCreated,
            [DbType(typeof (Boolean))]
            IsModerated,
            [DbType(typeof (Int32))]
            UpVote,
            [DbType(typeof (Int32))]
            DownVote,
            [DbType(typeof (Int32))]
            WatchNumber
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsModerated { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public int WatchNumber { get; set; }

        public ArticleDto ToDto() {
            return new ArticleDto {
                Id = Id,
                AuthorId = AuthorId,
                Title = Title,
                Text = Text,
                DateCreated = DateCreated,
                IsModerated = IsModerated,
                UpVote = UpVote,
                DownVote = DownVote,
                WatchNumber = WatchNumber
            };
        }
    }
}