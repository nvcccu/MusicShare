namespace Core.TransportTypes {
    public class ProductPropertyValueDto {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public int? PropertyValueId { get; set; }
    }
}