using System.Collections.Generic;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class FormParameter {
        public string Name { get; set; }
        public List<FormTransportType> Forms { get; set; }
        public List<ColorTransportType> Colors { get; set; }
        public List<FormWithColorTransportType> FormsWithColor { get; set; }
    }
}