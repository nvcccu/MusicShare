using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class NewProductsModel {
        public long ProductTypeId { get; set; }
        public Dictionary<int, int?> PropertyValuePairs { get; set; }
        public string ImageUrl { get; set; }

        public NewProductsModel() {
//            var propertiesDictionary = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProperties();
//            ProductTypes = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductTypes();
//            Properties = propertiesDictionary.Select(pd => pd.Value).SelectMany(pdv => pdv.Keys).ToList();
//            PropertyValues = propertiesDictionary.Select(pd => pd.Value).SelectMany(pdv => pdv.Values).SelectMany(pdv => pdv).ToList();
        }
    }
}