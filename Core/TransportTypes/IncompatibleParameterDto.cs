namespace Core.TransportTypes {
    public class IncompatibleParameterDto {
        public int Id { get; set; }
        public int ParameterId { get; set; }
        public int ParameterValueId { get; set; }
        public int IncompatibleParameterId { get; set; }
        public int IncompatibleParameterValueId { get; set; }
    }
}