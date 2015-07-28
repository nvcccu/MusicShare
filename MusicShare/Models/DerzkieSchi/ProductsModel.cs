using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class ProductsModel : BaseModel {
        public List<ProductTypeDto> ProductTypes { get; set; }
        public List<PropertyDto> Properties { get; set; }
        public List<PropertyValueDto> PropertyValues { get; set; }

        public ProductsModel(BaseModel baseModel) : base(baseModel) {
            var propertiesDictionary = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProperties();
            ProductTypes = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductTypes();
            Properties = propertiesDictionary.Select(pd => pd.Value).SelectMany(pdv => pdv.Keys).ToList();
            PropertyValues = propertiesDictionary.Select(pd => pd.Value).SelectMany(pdv => pdv.Values).SelectMany(pdv => pdv).ToList();
        }
    }

    public class FilterProductModel {
        public int ProductTypeId { get; set; }
        public string NamePart { get; set; }
        public Dictionary<string, string> PropertyValuePairs { get; set; }

        public List<ProductDto> GetFilteredProduct() {
            int tmpInt;
            var dictionary = PropertyValuePairs
                .ToDictionary(pvp => Convert.ToInt32(pvp.Key), pvp => Int32.TryParse(pvp.Value, out tmpInt) ? tmpInt : (int?)null)
                .Where(pvp => pvp.Value.HasValue)
                .ToDictionary(pvp => pvp.Key, pvp => pvp.Value.Value);
            return ServiceManager<IBusinessLogic>.Instance.Service.GetFilteredProducts(ProductTypeId, NamePart, dictionary);
        }
    }
}