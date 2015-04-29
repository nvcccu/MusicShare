using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.Ask {
    public class AskThreadModel : BaseModel {
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }

        public AskThreadModel(Account currentUser, long questionId) : base(currentUser) {
            var askThread = ServiceManager<IBusinessLogic>.Instance.Service.GetAskThread(questionId);
            Question = askThread.Question;
            Answers = askThread.Answers;
        }
    }
}