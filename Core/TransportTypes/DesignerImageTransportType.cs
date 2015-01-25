using System.Collections.Generic;

namespace Core.TransportTypes {
    public class DesignerImageTransportType {
        public DesignerImageDto DesignerImage { get; set; }
        public List<DesignerImagePositionDto> DesignerImagePositions { get; set; }
    }
}