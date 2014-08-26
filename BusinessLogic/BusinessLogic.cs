using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using Core.TransportTypes;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic{
        private readonly SearchProvider _searchProvider = new SearchProvider();

        public void Initial() {
            // todo: инициализация, если нужна
        }

        public List<GuitarTransportType> Search(short brand, short form, short color) {
            return _searchProvider.Search(brand, form, color);
        }

        public GuitarTransportType GetSampleGuitar(short? brand, short? form, short? color) {
            return _searchProvider.GetSampleGuitar(brand, form, color);
        }

        public List<BrandTransportType> GetAllBrand() {
            return _searchProvider.GetAllBrand();
        }

        public List<FormTransportType> GetAllForm() {
            return _searchProvider.GetAllForm();
        }

        public List<ColorTransportType> GetAllColor() {
            return _searchProvider.GetAllColor();
        }
    }
}