using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ISearchProvider {
        List<GuitarTransportType> Search(int brand, int formId, int color);
        List<GuitarWithColorTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId);
        List<SearchHintTransportType> GetSearchHints();
        List<BrandTransportType> GetAllBrand();
        List<FormTransportType> GetAllForms();
        List<ColorTransportType> GetAllColors();
        List<FormWithColorTransportType> GetAllFormsWithColor();
        List<BridgeTransportType> GetAllBridges();
        List<BridgeOnFormTransportType> GetAllBridgesOnForms();
        List<ColorSimpleTransportType> GetAllSimpleColors();
        List<ColorFullTransportType> GetAllFullColors();
        List<GuitarTransportType> GetAllGuitars();
        List<GuitarWithModelTransportType> GetAllGuitarsWithModel();
        List<NewsTransportType> GetLastNews();
    }
}