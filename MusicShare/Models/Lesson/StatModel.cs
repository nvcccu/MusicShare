using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class StatModel : BaseModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public Dictionary<int, List<ExerciseSpeedInDate>> ExercisesStats { get; set; }

        public StatModel(BaseModel baseModel) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
            ExercisesStats = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesTotalStat(CurrentUser.Id);
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetAllExercises();
        }
    }
}