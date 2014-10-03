namespace Core.TransportTypes {
    public class GuitarSummaryTransportType {
        public int GuitarId { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public int ColorFullId { get; set; }
        public string ColorFullName { get; set; }
        public string Model { get; set; }
        public bool Available { get; set; }
    }
}