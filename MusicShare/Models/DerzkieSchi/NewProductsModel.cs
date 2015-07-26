using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class NewProductsModel {
        public int ProductTypeId { get; set; }
        public Dictionary<string, string> PropertyValuePairs { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int? SaveNewProduct() {
            int tmpInt;
            var propertyValuePairs = PropertyValuePairs.ToDictionary(apvp => Convert.ToInt32(apvp.Key), apvp => Int32.TryParse(apvp.Value, out tmpInt) ? tmpInt : (int?)null);
            return ServiceManager<IBusinessLogic>.Instance.Service.SaveNewProduct(ProductTypeId, propertyValuePairs, ImageUrl, Name, Price);
        }
    }
}