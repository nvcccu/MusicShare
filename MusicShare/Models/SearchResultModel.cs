using System.Collections.Generic;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class SearchResultModel : BaseModel {
        public List<GuitarTransportType> SearchResults { get; set; }

        public SearchResultModel(List<GuitarTransportType> gtt) {
            SearchResults = gtt;
        }
    }
}