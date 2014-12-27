using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IStoreProvider {
        List<OfferCategoryTransportType> GetAllOfferCategories();
    }
}