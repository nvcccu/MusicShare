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
                ss.Value.ForEach(l => {
                    ret += l.Key + "-" + l.Value;
                });
                ret += ";";
            });
            return ret;
        }
        private LessonStatDto CreateBaseLessonStat(int accountId) {
            var lessonStat = new LessonStat {
                AccountId = accountId,
                ExerciseSpeed = "1:1-60,1-60,1-60,1-60,1-60,1-60,1-60,1-60,1-60,1-60,1-60,1-60;"
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
                lessonStat.ExerciseSpeed = ArchiveExerciseSpeed(lessonStatDto.ExerciseSpeed);
                lessonStat.Save();
            } else {
                CreateBaseLessonStat(lessonStatDto.AccountId);
            }
                
        }
    }
}