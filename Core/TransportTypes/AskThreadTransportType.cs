using System.Collections.Generic;

namespace Core.TransportTypes {
    public class AskThreadTransportType {
        public QuestionDto Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}