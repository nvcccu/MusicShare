using System;
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
                .OrderBy(Question.Fields.Id, OrderType.Desc)
                .GetData()
                .ToList();
            var answers = new Answer()
                .Select()
                .Where(Answer.Fields.AnswerTo, PredicateCondition.In, questions.Select(q => q.Id).ToList())
                .GetData()
                .ToList();
            return questions.Select(q => {
                var solution = answers.SingleOrDefault(a => a.AnswerTo == q.Id && a.IsSolution);
                return new QuestionTransportType {
                    Question = q.ToDto(),
                    SolutionText = solution != null ? solution.Text : null
                };
            }).ToList();
        }
        public long CreateNewQuestion(QuestionDto question) {
            return Convert.ToInt64(new Question {
                Title = question.Title,
                Text = question.Text,
                AccountId = question.AccountId,
                DateCreated = DateTime.Now,
                VoteNumber = 0,
                WatchNumber = 0
            }.Insert());
        }
    }
}