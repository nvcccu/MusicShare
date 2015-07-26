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
}