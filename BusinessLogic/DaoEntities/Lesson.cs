using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Lesson : AbstractEntity<Lesson> {
        public Lesson(string tableName) : base(tableName) {}

        public Lesson() : base("Lesson") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            GuitarTechniqueId,
            [DbType(typeof (Int32))]
            OrderNumber,
            [DbType(typeof (Int32))]
            PreviousLessonId,
            [DbType(typeof (Int32))]
            NextLessonId,
            [DbType(typeof (string))]
            Description,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            Text,
            [DbType(typeof (string))]
            OriginalLessonUrl,
            [DbType(typeof (Boolean))]
            IsModerated
        }

        public int Id { get; set; }
        public int GuitarTechniqueId { get; set; }
        public int OrderNumber { get; set; }
        public int? PreviousLessonId { get; set; }
        public int? NextLessonId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string OriginalLessonUrl { get; set; }
        public bool IsModerated { get; set; }

        public LessonDto ToDto() {
            return new LessonDto {
                Id = Id,
                GuitarTechniqueId = GuitarTechniqueId,
                OrderNumber = OrderNumber,
                PreviousLessonId = PreviousLessonId,
                NextLessonId = NextLessonId,
                Description = Description,
                Name = Name,
                Text = Text,
                OriginalLessonUrl = OriginalLessonUrl,
                IsModerated = IsModerated
            };
        }
    }
}