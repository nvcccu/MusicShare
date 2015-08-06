using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonModel : BaseModel {
        public LessonDto Lesson { get; set; }
        public Dictionary<int, int> Speeds { get; set; }

        public LessonModel(BaseModel baseModel, int lessonId) : base(baseModel) {
            Lesson = ServiceManager<IBusinessLogic>.Instance.Service.GetLesson(lessonId);
            Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersLessonStat(lessonId, CurrentUser.Id);
        }
        public LessonModel(BaseModel baseModel) : base(baseModel) { }

        public void SaveExercisesSpeed(int lessonId) {
            ServiceManager<IBusinessLogic>.Instance.Service.SaveUsersLessonStat(CurrentUser.Id, lessonId, Speeds);
        }
    }
}