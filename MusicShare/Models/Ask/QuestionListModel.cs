using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Ask {
    public class QuestionListModel : BaseModel {
        public List<QuestionTransportType> Questions { get; set; }

        public QuestionListModel(BaseModel baseModel) : base(baseModel) {
            Questions =  ServiceManager<IBusinessLogic>.Instance.Service.GetAllQuestions();
        }
    }
}