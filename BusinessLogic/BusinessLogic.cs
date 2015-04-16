using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils.Config;
using Core.Enums;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic {
        private readonly UserProvider _userProvider = new UserProvider();
        private readonly LogProvider _logProvider = new LogProvider();
        private readonly DerzkieSchiProvider _derzkieSchiProvider = new DerzkieSchiProvider();
        private readonly DesignerProvider _designerProvider = new DesignerProvider();
        private readonly AskProvider _askProvider = new AskProvider();
        public BusinessLogic() {
            Initial();
        }
        public void Initial() {
            ConfigHelper.LoadXml(false);
            Connector.ConnectionString = ConfigHelper.FirstTagWithTagNameInnerText("db-connection");
        }
        public long GetNextGuestId(string userAgent) {
            return _userProvider.GetNextGuestId(userAgent);
        }
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            _logProvider.AddUserAction(guestId, actionId, target);
        }
        public List<ParameterDto> GetParameters() {
            return _designerProvider.GetParameters();
        }
        public List<ParameterValueDto> GetParameterValues() {
            return _designerProvider.GetParameterValues();
        }
        public List<IncompatibleParameterDto> GetIncompatibleParameters() {
            return _designerProvider.GetIncompatibleParameters();
        }
        public List<DesignerImageTransportType> GetDesignerImages() {
            return _designerProvider.GetDesignerImages();
        }
        public List<PredefinedGuitarDto> GetPredefinedGuitars() {
            return _designerProvider.GetPredefinedGuitars();
        }
        public AskThreadTransportType GetAskThread(long questionId) {
            return _askProvider.GetAskThread(questionId);
        }
        public List<QuestionTransportType> GetAllQuestions() {
            return _askProvider.GetAllQuestions();
        }
        public long CreateNewQuestion(QuestionDto question) {
            return _askProvider.CreateNewQuestion(question);
        }
    }
}