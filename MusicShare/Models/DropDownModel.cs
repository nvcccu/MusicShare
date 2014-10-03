using System.Collections.Generic;

namespace MusicShareWeb.Models {
    public class DropDownModel {
        public string Name { get; set; }
        public string SelectedId { get; set; }
        public Dictionary<string, string> KeyValues { get; set; }
    }
}