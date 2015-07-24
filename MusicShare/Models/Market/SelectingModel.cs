using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Market {
    public class SelectingModel : BaseModel {
        public long CategoryId { get; set; }
        public Dictionary<PropertyDto, List<PropertyValueDto>> Properties { get; set; }

        public SelectingModel(BaseModel baseModel) : base(baseModel) {}
        public SelectingModel(BaseModel baseModel, long categoryId) : base(baseModel) {
            CategoryId = categoryId;
            Properties = ServiceManager<IBusinessLogic>.Instance.Service.GetAllProductProperties(CategoryId);
        }
    }
}