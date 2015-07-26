using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Market {
    public class SelectingModel : BaseModel {
        public ProductTypeDto SelectedProductType { get; set; }
        public List<ProductTypeDto> AllProductTypes { get; set; }
        public Dictionary<PropertyDto, List<PropertyValueDto>> Properties { get; set; }

        public SelectingModel(BaseModel baseModel) : base(baseModel) {}
        public SelectingModel(BaseModel baseModel, long selectedProductTypeId) : base(baseModel) {
            AllProductTypes = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductTypes();
            SelectedProductType = AllProductTypes.First(pt => pt.Id == selectedProductTypeId);
            Properties = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductProperties(SelectedProductType.Id);
        }
    }
}