namespace Core.TransportTypes {
    public class ParameterDto {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string NameNominative { get; set; }
        public string NameGenitive { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
}