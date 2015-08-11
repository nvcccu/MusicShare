using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Exercise : AbstractEntity<Exercise> {
        public Exercise(string tableName) : base(tableName) {}

        public Exercise() : base("Exercise") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            LessonId,
            [DbType(typeof(String))]
            Name,
            [DbType(typeof(String))]
            ImageUrl,
            [DbType(typeof(String))]
            AudioUrl,
            [DbType(typeof(Int32))]
            AuthorAccountId,
            [DbType(typeof(Boolean))]
            IsPublic
        }

        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public int AuthorAccountId { get; set; }
        public bool IsPublic { get; set; }

        public ExerciseDto ToDto() {
            return new ExerciseDto {
                Id = Id,
                LessonId = LessonId,
                Name = Name,
                ImageUrl = ImageUrl,
                AudioUrl = AudioUrl,
                AuthorAccountId = AuthorAccountId,
                IsPublic = IsPublic
            };
        }
    }
}