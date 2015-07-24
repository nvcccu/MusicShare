using System.Collections.Generic;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Market {
    public class CategoryListModel : BaseModel {
        public List<ProductTypeDto> Categories { get; set; }
        public CategoryListModel(BaseModel baseModel) : base(baseModel) {}
    }
}