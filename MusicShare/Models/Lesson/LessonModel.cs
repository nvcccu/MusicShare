using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonModel : BaseModel {
        public int LessonId { get; set; }
        public Dictionary<int, int> Speeds { get; set; }

        public LessonModel(BaseModel baseModel, int id) : base(baseModel) {
            LessonId = id;
            Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersLessonStat(CurrentUser.Id).ExercisesSpeed[1];
        }
        public LessonModel(BaseModel baseModel, int lessonId, Dictionary<int, int> speeds) : base(baseModel) {
            LessonId = lessonId;
            Speeds = speeds;
        }
        public void SaveExercisesSpeed() {
            ServiceManager<IBusinessLogic>.Instance.Service.SaveUsersLessonStat(new LessonStatDto {
                AccountId = CurrentUser.Id,
                ExercisesSpeed = new Dictionary<int, Dictionary<int, int>> { { 1, Speeds } }
            });
        }
    }
}