using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class TrainModel : BaseModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public Dictionary<int, int> Speeds { get; set; }
        public PlanDto Plan { get; set; }

        public TrainModel(BaseModel baseModel) : base(baseModel) {}
        public TrainModel(BaseModel baseModel, int planId) : base(baseModel) {
            Plan = ServiceManager<IBusinessLogic>.Instance.Service.GetPlan(planId);
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllModeratedLessons();
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetExercisesByPlan(planId);
            if(CurrentUser != null) {
                var exerciseIds = Exercises.Select(e => e.Id).ToList();
                Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesStat(CurrentUser.Id)
                    .Where(es => exerciseIds.Contains(es.Key))
                    .ToDictionary(es => es.Key, es => es.Value);
            } else {
                Speeds = new Dictionary<int, int>();
            }
        }

        public void UpdateExercisesSpeed(int accountId, Dictionary<string, string> exercisesSpeed) {
            ServiceManager<IBusinessLogic>.Instance.Service.SaveUsersLessonStat(accountId,
                exercisesSpeed.ToDictionary(es => Convert.ToInt32(es.Key), es => Convert.ToInt32(es.Value)));
        }
    }
}