namespace Core.TransportTypes {
    public class GuitarSummaryTransportType {
        public int GuitarWithColorId { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public int ColorFullId { get; set; }
        public string ColorFullName { get; set; }
        public int ModelId { get; set; }
        public bool Available { get; set; }
        public bool IsGreatQualityPhoto { get; set; }
    }
}