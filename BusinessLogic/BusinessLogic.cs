using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils;
using CommonUtils.Config;
using Core.Enums;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic {
        private readonly SearchProvider _searchProvider = new SearchProvider();
        private readonly UserProvider _userProvider = new UserProvider();
        private readonly LogProvider _logProvider = new LogProvider();

        public BusinessLogic() {
            Initial();
        }

        public void Initial() {
            ConfigHelper.LoadXml(false);
            Connector.ConnectionString = ConfigHelper.FirstTagWithPropertyText("db-connection", "db-name", "master");
        }

        public List<GuitarTransportType> Search(int brand, int formId, int color) {
            return _searchProvider.Search(brand, formId, color);
        }

        public List<GuitarWithColorTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId) {
            return _searchProvider.GetSampleGuitars(brandId, formId, simpleColorId);
        }

        public List<GuitarSummaryTransportType> GetGuitarsSummary() {
            return _searchProvider.GetGuitarsSummary();
        }

        public bool SaveGuitarSummary(GuitarSummaryTransportType guitarSummary) {
            return _searchProvider.SaveGuitarSummary(guitarSummary);
        }

        public List<SearchHintTransportType> GetSearchHints() {
            return _searchProvider.GetSearchHints();
        }

        public List<BrandTransportType> GetAllBrand() {
            return _searchProvider.GetAllBrand();
        }

        public List<FormTransportType> GetAllForm() {
            return _searchProvider.GetAllForm();
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

        public List<NewsTransportType> GetLastNews() {
            return _searchProvider.GetLastNews();
        }

        public long GetNextGuestId(string userAgent) {
            return _userProvider.GetNextGuestId(userAgent);
        }

        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            _logProvider.AddUserAction(guestId, actionId, target);
        }
    }
}