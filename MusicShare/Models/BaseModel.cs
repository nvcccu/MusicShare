using System;
using System.Collections.Generic;

namespace MusicShareWeb.Models {
    public class BaseModel {
        /// <summary>
        /// 
        /// </summary>
        public List<string> Test { get; set; }

        public BaseModel() {
            Test = new List<string>();

        }
    }
}