using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic.Helpers {
    public static class ParserHelper {
        public static List<OfferCategoryTransportType> GetAllOfferCategories() {
            return new OfferCategory()
                .Select()
                .OrderBy(OfferCategory.Fields.Id, OrderType.Asc)
                .GetData()
                .Select(oc => oc.ToTransport())
                .ToList();
        }

        public static List<OfferTransportType> GetAllOffers() {
            return new Offer()
                .Select()
                .OrderBy(Offer.Fields.Id, OrderType.Asc)
                .GetData()
                .Select(oc => oc.ToTransport())
                .ToList();
        } 
    }
}