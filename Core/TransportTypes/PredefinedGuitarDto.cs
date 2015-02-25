using System.Collections.Generic;

namespace Core.TransportTypes {
    public class PredefinedGuitarDto {
        public int Id { get; set; }
        public int FormId { get; set; }
        public Dictionary<int, int> ParameterValues { get; set; }
    }
}