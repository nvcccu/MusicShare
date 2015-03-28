using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Question : AbstractEntity<Question> {
        public Question(string tableName) : base(tableName) {}

        public Question() : base("Question") {}

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (Int32))]
            AccountId,
            [DbType(typeof (string))]
            Title,
            [DbType(typeof (string))]
            Text,
            [DbType(typeof (DateTime))]
            DateCreated,
            [DbType(typeof (Int32))]
            WatchNumber,
            [DbType(typeof (Int32))]
            VoteNumber
        }

        public long Id { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public int WatchNumber { get; set; }
        public int VoteNumber { get; set; }

        public QuestionDto ToDto() {
            return new QuestionDto {
                Id = Id,
                Title = Title,
                Text = Text,
                AccountId = AccountId,
                DateCreated = DateCreated,
                WatchNumber = WatchNumber,
                VoteNumber = VoteNumber
            };
        }
    }
}