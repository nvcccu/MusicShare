using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using Core.TransportTypes;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic{
        private readonly SearchProvider _searchProvider = new SearchProvider();

        public void Initial() {
            
        }

        public List<GuitarTransportType> Search(string brand, string model, string color) {
            return _searchProvider.Search(brand, model, color);
        }

        public GuitarTransportType GetSampleGuitar(string brand, string model, string color) {
            return _searchProvider.GetSampleGuitar(brand, model, color);
        }

        public List<BrandTransportType> GetAllBrand() {
            return _searchProvider.GetAllBrand();
        }

        public List<FormTransportType> GetAllForm() {
            return _searchProvider.GetAllForm();
        }
    }
}