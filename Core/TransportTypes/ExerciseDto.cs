namespace Core.TransportTypes {
    public class ExerciseDto {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public int AuthorAccountId { get; set; }
        public bool IsPublic { get; set; }
    }
}