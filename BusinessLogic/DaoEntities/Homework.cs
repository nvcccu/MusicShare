using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Homework : AbstractEntity<Homework> {
        public Homework(string tableName) : base(tableName) {}

        public Homework() : base("Homework") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            AccountId,
            [DbType(typeof (Int32))]
            LessonId,
            [DbType(typeof (DateTime))]
            DateCreated,
            [DbType(typeof (String))]
            Link
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LessonId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Link { get; set; }

        public HomeworkDto ToDto() {
            return new HomeworkDto {
                Id = Id,
                AccountId = AccountId,
                LessonId = LessonId,
                DateCreated = DateCreated,
                Link = Link
            };
        }
    }
}