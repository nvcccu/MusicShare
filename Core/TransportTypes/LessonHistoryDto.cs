using System;

namespace Core.TransportTypes {
    public class LessonHistoryDto {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int LessonId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string Comment { get; set; }
    }
}