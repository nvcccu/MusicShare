using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class SearchModel : BaseModel {
        /// <summary>
        /// 
        /// </summary>
        public List<BrandTransportType> Brands { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FormTransportType> Forms { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColorSimpleTransportType> Colors { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SearchHintTransportType> SearchHints { get; private set; } 

        public SearchModel() {
            Brands = ServiceManager<IBusinessLogic>.Instance.Service.GetAllBrand();
            Forms = ServiceManager<IBusinessLogic>.Instance.Service.GetAllForm();
            Colors = ServiceManager<IBusinessLogic>.Instance.Service.GetAllColor();
            SearchHints = ServiceManager<IBusinessLogic>.Instance.Service.GetSearchHints();
        }
    }
}