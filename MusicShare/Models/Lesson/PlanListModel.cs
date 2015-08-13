using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class PlanListModel : BaseModel {
        public List<PlanDto> Plans { get; set; }
       
        public PlanListModel(BaseModel baseModel) : base(baseModel) {
            Plans = ServiceManager<IBusinessLogic>.Instance.Service.GetAllUsersPlans(CurrentUser.Id);
        }
    }
}