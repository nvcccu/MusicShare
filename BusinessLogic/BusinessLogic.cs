using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils.Config;
using Core.Enums;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic {
        private readonly SearchProvider _searchProvider = new SearchProvider();
        private readonly UserProvider _userProvider = new UserProvider();
        private readonly LogProvider _logProvider = new LogProvider();
        private readonly DerzkieSchiProvider _derzkieSchiProvider = new DerzkieSchiProvider();
        private readonly StoreProvider _storeProvider = new StoreProvider();
        private readonly DesignerProvider _designerProvider = new DesignerProvider();
        public BusinessLogic() {
            Initial();
        }
        public void Initial() {
            ConfigHelper.LoadXml(false);
            Connector.ConnectionString = ConfigHelper.FirstTagWithTagNameInnerText("db-connection");
        }
        public List<GuitarTransportType> Search(int brand, int formId, int color) {
            return _searchProvider.Search(brand, formId, color);
        }
        public List<GuitarWithColorTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId) {
            return _searchProvider.GetSampleGuitars(brandId, formId, simpleColorId);
        }
        public List<GuitarSummaryTransportType> GetGuitarsSummary() {
            return _derzkieSchiProvider.GetGuitarsSummary();
        }
        public bool SaveGuitarSummary(GuitarSummaryTransportType guitarSummary) {
            return _derzkieSchiProvider.SaveGuitarSummary(guitarSummary);
        }
        public bool SaveNewGuitar(GuitarSummaryTransportType guitarSummary) {
            return _derzkieSchiProvider.SaveNewGuitar(guitarSummary);
        }
        public bool UpdateGuitarModel(GuitarWithModelTransportType guitarModel) {
            return _derzkieSchiProvider.UpdateGuitarModel(guitarModel);
        }
        public bool SaveNewGuitarModel(GuitarWithModelTransportType guitarModel) {
            return _derzkieSchiProvider.SaveNewGuitarModel(guitarModel);
        }
        public bool UpdateGuitarColor(GuitarWithColorTransportType guitarColor) {
            return _derzkieSchiProvider.UpdateGuitarColor(guitarColor);
        }
        public bool SaveNewGuitarColor(GuitarWithColorTransportType guitarColor) {
            return _derzkieSchiProvider.SaveNewGuitarColor(guitarColor);
        }
        public List<SearchHintTransportType> GetSearchHints() {
            return _searchProvider.GetSearchHints();
        }
        public List<BrandTransportType> GetAllBrand() {
            return _searchProvider.GetAllBrand();
        }
        public List<ColorTransportType> GetAllColors() {
            return _searchProvider.GetAllColors();
        }
        public List<ColorSimpleTransportType> GetAllSimpleColors() {
            return _searchProvider.GetAllSimpleColors();
        }
        public List<ColorFullTransportType> GetAllFullColors() {
            return _searchProvider.GetAllFullColors();
        }
        public List<GuitarTransportType> GetAllGuitars() {
            return _searchProvider.GetAllGuitars();
        }
        public List<GuitarWithModelTransportType> GetAllGuitarsWithModel() {
            return _searchProvider.GetAllGuitarsWithModel();
        }
        public List<NewsTransportType> GetLastNews() {
            return _searchProvider.GetLastNews();
        }
        public long GetNextGuestId(string userAgent) {
            return _userProvider.GetNextGuestId(userAgent);
        }
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            _logProvider.AddUserAction(guestId, actionId, target);
        }
        public List<OfferCategoryTransportType> GetAllOfferCategories() {
            return _storeProvider.GetAllOfferCategories();
        }
        public List<ParameterDto> GetParameters() {
            return _designerProvider.GetParameters();
        }
        public List<ParameterValueDto> GetParameterValues() {
            return _designerProvider.GetParameterValues();
        }
        public List<IncompatibleParameterDto> GetIncompatibleParameters() {
            return _designerProvider.GetIncompatibleParameters();
        }
        public List<DesignerImageTransportType> GetDesignerImages() {
            return _designerProvider.GetDesignerImages();
        }
        public List<PredefinedGuitarDto> GetPredefinedGuitars() {
            return _designerProvider.GetPredefinedGuitars();
        }
    }
}