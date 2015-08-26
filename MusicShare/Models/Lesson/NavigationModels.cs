using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonNavigationModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
       
        public LessonNavigationModel() {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
        }
    }

    public class PlanNavigationModel {
        public List<PlanDto> Plans { get; set; }
          public bool IsAuthorized { get; set; }
       
        public PlanNavigationModel(bool isAuthorized, int? accoutnId = null) {
            Plans = accoutnId.HasValue
                ? ServiceManager<IBusinessLogic>.Instance.Service.GetAllUsersPlans(accoutnId.Value)
                : new List<PlanDto>();
            IsAuthorized = isAuthorized;
        }
    }
}