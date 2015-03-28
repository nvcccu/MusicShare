using System.Collections.Generic;

namespace MusicShareWeb.Models {
    public class BaseModel {
        public List<string> Test { get; set; }

        public BaseModel() {
            Test = new List<string>();
        }
    }
}