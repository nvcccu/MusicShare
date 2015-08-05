using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonListModel : BaseModel {
        public Dictionary<GuitarTechniqueDto, List<LessonDto>> Lessons { get; set; }

        public LessonListModel(BaseModel baseModel) : base(baseModel) {
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessonsGroupedByTechnique();
        }
    }
}