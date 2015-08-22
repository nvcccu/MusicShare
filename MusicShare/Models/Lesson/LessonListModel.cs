using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonListModel : BaseModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<PlanDto> Plans { get; set; }
       
        public LessonListModel(BaseModel baseModel) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
            Plans = CurrentUser != null ? ServiceManager<IBusinessLogic>.Instance.Service.GetAllUsersPlans(CurrentUser.Id) : new List<PlanDto>();
        }
    }
}