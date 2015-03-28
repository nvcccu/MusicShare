using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class AskProvider : IAskProvider {
        public AskThreadTransportType GetAskThread(long questionId) {
            var question = new Question()
                .Select()
                .Where(Question.Fields.Id, PredicateCondition.Equal, questionId)
                .GetData()
                .Select(p => p.ToDto())
                .Single();
            var answers = new Answer()
                .Select()
                .Where(Answer.Fields.AnswerTo, PredicateCondition.Equal, questionId)
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            return new AskThreadTransportType {
                Question = new Question()
                    .Select()
                    .Where(Question.Fields.Id, PredicateCondition.Equal, questionId)
                    .GetData()
                    .Select(p => p.ToDto())
                    .Single(),
                Answers = new Answer()
                    .Select()
                    .Where(Answer.Fields.AnswerTo, PredicateCondition.Equal, questionId)
                    .GetData()
                    .Select(p => p.ToDto())
                    .ToList()
            };
        }
    }
}