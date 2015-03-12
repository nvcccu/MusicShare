namespace Core.TransportTypes {
    public class ParameterArrowDto {
        public int Id { get; set; }
        public int ParameterId { get; set; }
        public int? FormId { get; set; }
        public int ArrowLeft { get; set; }
        public int ArrowTop { get; set; }
        public int TextLeft { get; set; }
        public int TextTop { get; set; }
        public string Url { get; set; }
    }
}