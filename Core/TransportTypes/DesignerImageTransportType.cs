using System.Collections.Generic;

namespace Core.TransportTypes {
    public class DesignerImageTransportType {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<DesignerImagePositionDto> DesignerImagePositions { get; set; }
    }
}