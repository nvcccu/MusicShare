using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models {
    public class GuitarTotalDataModel : BaseModel {
        /// <summary>
        /// 
        /// </summary>
        public List<BrandTransportType> Brands { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColorSimpleTransportType> SimpleColors { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ColorFullTransportType> FullColors { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<GuitarWithModelTransportType> GuitarsWithModel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// NOTE: пока не успользуется
        public List<SearchHintTransportType> SearchHints { get; private set; } 

        /// <summary>
        /// 
        /// </summary>
        public List<GuitarTransportType> Guitars { get; private set; } 

        public GuitarTotalDataModel() {
            Brands = ServiceManager<IBusinessLogic>.Instance.Service.GetAllBrand();
            SimpleColors = ServiceManager<IBusinessLogic>.Instance.Service.GetAllSimpleColors();
            FullColors = ServiceManager<IBusinessLogic>.Instance.Service.GetAllFullColors();
            SearchHints = ServiceManager<IBusinessLogic>.Instance.Service.GetSearchHints();
            Guitars = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitars();
            GuitarsWithModel = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarsWithModel();
        }
    }
}