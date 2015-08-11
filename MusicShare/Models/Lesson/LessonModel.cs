using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonModel : BaseModel {
        public LessonDto Lesson { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public GuitarTechniqueDto GutarTechique { get; set; }
        public Dictionary<int, int> Speeds { get; set; }

        public LessonModel(BaseModel baseModel, int lessonId) : base(baseModel) {
            Lesson = ServiceManager<IBusinessLogic>.Instance.Service.GetLesson(lessonId);
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetLessonExercises(lessonId);
            GutarTechique = ServiceManager<IBusinessLogic>.Instance.Service.GetGuitarTechnique(Lesson.GuitarTechniqueId);
            if(CurrentUser != null) {
                Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersLessonStat(lessonId, CurrentUser.Id);
            } else {
                Speeds = new Dictionary<int, int>(Lesson.ExerciseNumber);
                Exercises.ForEach(e => Speeds.Add(e.Id, 60));
            }
        }
        public LessonModel(BaseModel baseModel) : base(baseModel) { }

        public void SaveExercisesSpeed(int lessonId) {
            ServiceManager<IBusinessLogic>.Instance.Service.SaveUsersLessonStat(CurrentUser.Id, lessonId, Speeds);
        }
    }

    public class MinimizedLessonModel : BaseModel {
        public MinimizedLessonModel(BaseModel baseModel) : base(baseModel) { }
        public MinimizedLessonModel(BaseModel baseModel, int lessonId) : base(baseModel) {}
    }
}