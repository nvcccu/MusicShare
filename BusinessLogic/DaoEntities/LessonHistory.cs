using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class LessonHistory : AbstractEntity<LessonHistory> {
        public LessonHistory(string tableName) : base(tableName) {}

        public LessonHistory() : base("LessonHistory") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            AccountId,
            [DbType(typeof (Int32))]
            LessonId,
            [DbType(typeof (String))]
            Text,
            [DbType(typeof (DateTime))]
            DateCreated,
            [DbType(typeof (String))]
            Comment
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LessonId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string Comment { get; set; }

        public LessonHistoryDto ToDto() {
            return new LessonHistoryDto {
                Id = Id,
                AccountId = AccountId,
                LessonId = LessonId,
                Text = Text,
                DateCreated = DateCreated,
                Comment = Comment
            };
        }
    }
}