using System.Collections.Generic;

namespace Core.TransportTypes {
    public class LessonStatDto {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Dictionary<int, Dictionary<int, int>> ExerciseSpeed { get; set; }
    }
}