using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using Core.TransportTypes;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic{
        private SearchProvider _searchProvider = new SearchProvider();

        public void Initial() {
            
        }

        public List<GuitarTransportType> Search(string brand, string model, string color) {
            return _searchProvider.Search(brand, model, color);
        }
    }
}