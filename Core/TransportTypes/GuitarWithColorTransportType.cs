namespace Core.TransportTypes {
    public class GuitarWithColorTransportType {
        public int Id { get; set; }
        public int GuitarId { get; set; }
        public int ColorId { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsGreatQualityPhoto { get; set; }
    }
}