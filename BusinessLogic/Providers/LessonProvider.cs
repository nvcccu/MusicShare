using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class LessonProvider : ILessonProvider {
        private string ArchiveExerciseSpeed(Dictionary<int, Dictionary<int, int>> speedStat) {
            var ret = String.Empty;
            speedStat.ForEach(ss => {
                ret += ss.Key + ":";
                ret += String.Join(",", ss.Value.Select(l => l.Key + "-" + l.Value)); ;
                ret += ";";
            });
            return ret;
        }
        private LessonStatDto CreateBaseLessonStat(int accountId) {
            var lessonStat = new LessonStat {
                AccountId = accountId,
                ExercisesSpeed = "1:1-60,2-60,3-60,4-60,5-60,6-60,7-60,8-60,9-60,10-60,11-60,12-60;"
            };
            lessonStat.Id = Convert.ToInt32(lessonStat.Insert());
            return lessonStat.ToDto();
        }
        public LessonStatDto GetUsersLessonStat(int accountId) {
            var lessonStat = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .SingleOrDefault();
            if(lessonStat != null) {
                return lessonStat.ToDto();
            } else {
                return CreateBaseLessonStat(accountId);
            }   
        }
        public void SaveUsersLessonStat(LessonStatDto lessonStatDto) {
            var lessonStat = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, lessonStatDto.AccountId)
                .GetData()
                .SingleOrDefault();
            if(lessonStat != null) {
                new LessonStat()
                    .Select()
                    .Update()
                    .Set(LessonStat.Fields.ExercisesSpeed, ArchiveExerciseSpeed(lessonStatDto.ExercisesSpeed))
                    .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, lessonStatDto.AccountId)
                    .ExecuteScalar();
            } else {
                CreateBaseLessonStat(lessonStatDto.AccountId);
            }
                
        }
    }
}