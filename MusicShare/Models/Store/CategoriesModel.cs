using System.Collections.Generic;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Store {
    public class CategoriesModel : BaseModel {
        public List<OfferCategoryTransportType> Categories { get; set; }
        public long Id { get; set; }

        public CategoriesModel(List<OfferCategoryTransportType> categories) {
            Categories = categories;
        }

        public CategoriesModel(List<OfferCategoryTransportType> categories, long id) {
            Categories = categories;
            Id = id;
        }
    }
}