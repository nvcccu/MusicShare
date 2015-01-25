using System.Collections.Generic;

namespace Core.TransportTypes {
    public class DesignerImageDto {
        public int Id { get; set; }
        public Dictionary<int, int> Parameters { get; set; }
        public string Url { get; set; }
    }
}