using System;

namespace Core.TransportTypes {
    public class HomeworkDto {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LessonId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Link { get; set; }
    }
}