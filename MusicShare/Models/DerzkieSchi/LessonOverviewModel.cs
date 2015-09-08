using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class LessonOverviewModel : BaseModel {
        public List<LessonDto> Lessons { get; set; }
        public List<LessonHistoryDto> LessonHistory { get; set; }

        public  LessonOverviewModel() {}
        public LessonOverviewModel(BaseModel baseModel) : base(baseModel) {
            Lessons = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessons();
            LessonHistory = ServiceManager<IBusinessLogic>.Instance.Service.GetAllLessonHistory();
        }
    }
}