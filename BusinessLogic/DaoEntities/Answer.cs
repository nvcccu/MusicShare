using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Answer : AbstractEntity<Answer> {
        public Answer(string tableName) : base(tableName) {}

        public Answer() : base("Answer") {}

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (Int32))]
            AccountId,
            [DbType(typeof (Int64))]
            AnswerTo,
            [DbType(typeof (String))]
            Text,
            [DbType(typeof (DateTime))]
            DateCreated,
            [DbType(typeof (Boolean))]
            IsSolution,
            [DbType(typeof (Int32))]
            VoteNumber
        }

        public long Id { get; set; }
        public int AccountId { get; set; }
        public long AnswerTo { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsSolution { get; set; }
        public int VoteNumber { get; set; }

        public AnswerDto ToDto() {
            return new AnswerDto {
                Id = Id,
                AccountId = AccountId,
                AnswerTo = AnswerTo,
                Text = Text,
                DateCreated = DateCreated,
                IsSolution = IsSolution,
                VoteNumber = VoteNumber
            };
        }
    }
}