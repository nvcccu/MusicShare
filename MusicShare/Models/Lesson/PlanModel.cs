using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class PlanModel : BaseModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public Dictionary<int, int> Speeds { get; set; }
        public PlanDto Plan { get; set; }

        public PlanModel(BaseModel baseModel) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetAllExercises();
            Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesStat(CurrentUser.Id);
            if(CurrentUser != null) {
                Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesStat(CurrentUser.Id);
            } else {
                Speeds = new Dictionary<int, int>();
            }
        }

        public PlanModel(BaseModel baseModel, int planId) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetAllExercises();
            Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesStat(CurrentUser.Id);
            if(CurrentUser != null) {
                Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesStat(CurrentUser.Id);
            } else {
                Speeds = new Dictionary<int, int>();
            }
            Plan = ServiceManager<IBusinessLogic>.Instance.Service.GetPlan(planId);
        }

        public int Save(PlanDto plan) {
            return ServiceManager<IBusinessLogic>.Instance.Service.SavePlan(plan);
        }
        public void Update(PlanDto plan) {
            ServiceManager<IBusinessLogic>.Instance.Service.UpdatePlan(plan);
        }
    }
}