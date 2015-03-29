using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class AskProvider : IAskProvider {
        public AskThreadTransportType GetAskThread(long questionId) {
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
                    .OrderBy(Answer.Fields.Id, OrderType.Desc)
                    .GetData()
                    .Select(p => p.ToDto())
                    .ToList()
            };
        }
        public List<QuestionTransportType> GetAllQuestions() {
            var questions = new Question()
                .Select()
//                .Join(JoinType.Left, new Answer(), RetrieveMode.Retrieve)
//                .On(Question.Fields.Id, PredicateCondition.Equal, Answer.Fields.AnswerTo)
                .OrderBy(Question.Fields.Id, OrderType.Desc)
                .GetData()
                .ToList();
            var answers = new Answer()
                .Select()
                .Where(Answer.Fields.AnswerTo, PredicateCondition.In, questions.Select(q => q.Id).ToList())
                .GetData()
                .ToList();

            return questions.Select(q => new QuestionTransportType {
                Question = q.ToDto(),
                HasSolution = answers.Any(a => a.AnswerTo == q.Id && a.IsSolution)
            }).ToList();
        }
    }
}