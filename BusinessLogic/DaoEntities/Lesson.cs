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
            [DbType(typeof (string))]
            Title,
            [DbType(typeof (string))]
            Text
        }

        public long Id { get; set; }
        public int GuitarTechniqueId { get; set; }
        public int OrderNumber { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public LessonDto ToDto() {
            return new LessonDto {
                Id = Id,
                GuitarTechniqueId = GuitarTechniqueId,
                OrderNumber = OrderNumber,
                Title = Title,
                Text = Text
            };
        }
    }
}