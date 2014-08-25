using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class SearchModel : BaseModel {
        /// <summary>
        /// 
        /// </summary>
        public List<BrandTransportType> Brands { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FormTransportType> Forms { get; set; }

        public SearchModel() {
            Brands = ServiceManager<IBusinessLogic>.Instance.Service.GetAllBrand();
            Forms = ServiceManager<IBusinessLogic>.Instance.Service.GetAllForm();
        }
    }
}