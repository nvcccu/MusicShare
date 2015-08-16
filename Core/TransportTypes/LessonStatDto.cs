using System;
using System.Collections.Generic;

namespace Core.TransportTypes {
    public class LessonStatDto {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Dictionary<int, int> ExercisesSpeed { get; set; }
        public DateTime Date { get; set; }
    }
}