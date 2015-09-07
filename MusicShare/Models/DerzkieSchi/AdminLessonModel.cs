using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class AdminLessonModel : BaseModel {
        public LessonDto Lesson { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<GuitarTechniqueDto> GuitarTechniques { get; set; }

        public AdminLessonModel() : base((Account)null) { }
        public AdminLessonModel(BaseModel baseModel) : base(baseModel) {
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
        }
        public AdminLessonModel(int lessonId, BaseModel baseModel) : base(baseModel) {
            Lesson = ServiceManager<IBusinessLogic>.Instance.Service.GetLesson(lessonId);
            GuitarTechniques = ServiceManager<IBusinessLogic>.Instance.Service.GetAllGuitarTechniques();
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
        }

        public bool UpdateLesson(LessonDto lesson) {
            return ServiceManager<IBusinessLogic>.Instance.Service.UpdateLesson(lesson);
        }
        public int CreateLesson(LessonDto lesson) {
            return ServiceManager<IBusinessLogic>.Instance.Service.CreateLesson(lesson);
        }
    }
}