namespace Core.TransportTypes {
    public class LessonDto {
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
        public string Keywords { get; set; }
        public string Title { get; set; }
    }
}