using System.Collections.Generic;
using CommonUtils.Patterns;
using Core.TransportTypes;

namespace BusinessLogic.Helpers {
    public class StoreHelper : Singleton<StoreHelper> {
        private List<OfferCategoryTransportType> _allOfferCategories;
        public List<OfferCategoryTransportType> AllOfferCategories {
            get { return _allOfferCategories ?? (_allOfferCategories = ParserHelper.GetAllOfferCategories()); }
        }

        private List<OfferTransportType> _allOffers;
        public List<OfferTransportType> AllOffers {
            get { return _allOffers ?? (_allOffers = ParserHelper.GetAllOffers()); }
        }
    }
}