namespace Core.TransportTypes {
    public class GuitarInShopTransportType {
        public int Id { get; set; }
        public int GuitarId { get; set; }
        public int StoreId { get; set; }
        public bool Available { get; set; }
        public int Price { get; set; }
    }
}