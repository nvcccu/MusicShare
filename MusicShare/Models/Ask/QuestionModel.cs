using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.Ask {
    public class QuestionModel : BaseModel {
        public string Title { get; set; }
        public string Text { get; set; }
        public int AccountId { get; set; }

        public QuestionModel(Account currentUser) : base(currentUser) {}
        public long CreateNewQuestion() {
            return ServiceManager<IBusinessLogic>.Instance.Service.CreateNewQuestion(ToDto());
        }

        QuestionDto ToDto() {
            return new QuestionDto {
                Title = Title,
                Text = Text,
//                AccountId = AccountId
                AccountId = 1 // пока нет аккаунтов
            };
        }
    }
}