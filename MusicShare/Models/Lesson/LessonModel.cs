﻿using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Lesson {
    public class LessonModel : BaseModel {
        public LessonDto Lesson { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public GuitarTechniqueDto GuitarTechique { get; set; }
        public List<PlanDto> Plans { get; set; }
        public Dictionary<int, int> Speeds { get; set; }
        public bool IsMinimized { get; set; }

        public LessonModel(BaseModel baseModel, int lessonId, bool isMinimized) : base(baseModel) {
            Lesson = ServiceManager<IBusinessLogic>.Instance.Service.GetModeratedLesson(lessonId);
            Exercises = ServiceManager<IBusinessLogic>.Instance.Service.GetLessonExercises(lessonId);
            GuitarTechique = ServiceManager<IBusinessLogic>.Instance.Service.GetGuitarTechnique(Lesson.GuitarTechniqueId);
            if(CurrentUser != null) {
                Plans = ServiceManager<IBusinessLogic>.Instance.Service.GetAllUsersPlans(CurrentUser.Id);
                Speeds = ServiceManager<IBusinessLogic>.Instance.Service.GetUsersLessonStat(lessonId, CurrentUser.Id);
            } else {
                Speeds = new Dictionary<int, int>(Exercises.Count);
                Exercises.ForEach(e => Speeds.Add(e.Id, e.DefaultSpeed));
                Plans = new List<PlanDto>();
            }
            IsMinimized = isMinimized;
        }
        public LessonModel(BaseModel baseModel) : base(baseModel) { }

        public void SaveExercisesSpeed() {
            ServiceManager<IBusinessLogic>.Instance.Service.SaveUsersLessonStat(CurrentUser.Id, Speeds);
        }
        public bool SaveHomework(int lessonId, string link) {
            return ServiceManager<IBusinessLogic>.Instance.Service.SaveHomework(new HomeworkDto {
                AccountId = CurrentUser.Id,
                LessonId = lessonId,
                Link = link
            });
        }
    }
}