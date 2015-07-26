namespace Core.TransportTypes {
    public class ProductDto {
        public int Id { get; set; }
        public long ProductTypeId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}