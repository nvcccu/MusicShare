using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Ask {
    public class AskThreadModel : BaseModel {
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }

        public AskThreadModel(BaseModel baseModel, long questionId) : base(baseModel) {
            var askThread = ServiceManager<IBusinessLogic>.Instance.Service.GetAskThread(questionId);
            Question = askThread.Question;
            Answers = askThread.Answers;
        }
    }
}