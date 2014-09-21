using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils;
using Core.Enums;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic{
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

        public List<GuitarTransportType> Search(short brand, short form, short color) {
            return _searchProvider.Search(brand, form, color);
        }

        public List<GuitarTransportType> GetSampleGuitars(short? brand, short? form, short? color) {
            return _searchProvider.GetSampleGuitars(brand, form, color);
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

        public List<ColorTransportType> GetAllColor() {
            return _searchProvider.GetAllColor();
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