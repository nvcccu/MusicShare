using System.Collections.Generic;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class BridgeParameter {
        public string Name { get; set; }
        public List<BridgeTransportType> Bridges { get; set; }
    }
}