using System.Collections.Generic;

namespace Core.TransportTypes {
    public class DesignerImagePositionDto {
        public int Id { get; set; }
        public int DesignerImageId { get; set; }
        public Dictionary<int, int> Parameters { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}