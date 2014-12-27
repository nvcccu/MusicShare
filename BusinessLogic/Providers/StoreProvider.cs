using System.Collections.Generic;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using Core.TransportTypes;

namespace BusinessLogic.Providers {
    public class StoreProvider : IStoreProvider {
        public List<OfferCategoryTransportType> GetAllOfferCategories() {
            return StoreHelper.Instance.AllOfferCategories;
        }
    }
}