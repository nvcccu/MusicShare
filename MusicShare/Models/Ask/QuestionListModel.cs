using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.Ask {
    public class QuestionListModel : BaseModel {
        public List<QuestionTransportType> Questions { get; set; }

        public QuestionListModel(Account currentUser) : base(currentUser) {
            Questions =  ServiceManager<IBusinessLogic>.Instance.Service.GetAllQuestions();
        }
    }
}