using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.Lesson {
    public class StatModel : BaseModel {
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public Dictionary<int, List<ExerciseSpeedInDate>> ExercisesStats { get; set; }
        public List<StatPresetDto> StatPresets { get; set; }

        public StatModel(BaseModel baseModel) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllModeratedLessons();
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetAllExercises();
            if(CurrentUser != null) {
                ExercisesStats = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersExercisesTotalStat(CurrentUser.Id);
                StatPresets = ServiceManager<IBusinessLogic>.Instance.Service.GetAllUsersStatPresets(CurrentUser.Id);
            } else {
                ExercisesStats = new Dictionary<int, List<ExerciseSpeedInDate>>();
                StatPresets = new List<StatPresetDto>();
            }
        }

        public StatModel() : base((Account)null) { }

        public bool DeleteStatPreset(int statPresetId) {
            ServiceManager<IBusinessLogic>.Instance.Service.DeleteStatPreset(statPresetId);
            return true;
        }
        public StatPresetDto SaveStatPreset(StatPresetDto statPreset) {
            return ServiceManager<IBusinessLogic>.Instance.Service.SaveStatPreset(statPreset);
        }
        public bool UpdateStatPresetName(int id, string name, List<string> exercises, int ownerAccountId) {
            return ServiceManager<IBusinessLogic>.Instance.Service.UpdateStatPreset(new StatPresetDto {
                Id = id,
                Name = name,
                Exercises = exercises!= null ? exercises.Select(e => Convert.ToInt32(e)).ToList() : null,
                OwnerAccountId = ownerAccountId
            });
        }
    }
}