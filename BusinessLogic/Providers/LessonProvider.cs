using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class LessonProvider : ILessonProvider {
        private string ArchiveLessonStat(int lessonId, Dictionary<int, int> speedStat) {
            return lessonId + ":" + String.Join(",", speedStat.Select(l => l.Key + "-" + l.Value)) + ";";
        }

        private string UpdateExerciseSpeed(string exercisesSpeed, Dictionary<int, Dictionary<int, int>> speedStat) {
            var ret = exercisesSpeed ?? String.Empty;
            speedStat.ForEach(ss => {
                var tmp = ArchiveLessonStat(ss.Key, ss.Value);
                if(ret.IndexOf(ss.Key + ":", StringComparison.Ordinal) > -1) {
                    var regex = new Regex(ss.Key + ":" + ".+?;");
                    ret = regex.Replace(ret, tmp);
                } else {
                    ret += tmp;
                }
            });
            return ret;
        }
//        private string GenerateBaseLessonStat() {
//            var lessons = new Lesson()
//                .Select()
//                .OrderBy(Lesson.Fields.Id, OrderType.Asc)
//                .GetData()
//                .Select(l => l.ToDto())
//                .ToList();
//            var speedStat = new Dictionary<int, Dictionary<int, int>>();
//            foreach(var lesson in lessons) {
//                var lessonStat = new Dictionary<int, int>();
//                for(var i = 0; i < lesson.ExerciseNumber; i++) {
//                    lessonStat.Add(i, 60);
//                }
//                speedStat.Add(lesson.Id, lessonStat);
//            }
//            return UpdateExerciseSpeed("", speedStat);
//        }
//        private LessonStatDto CreateBaseLessonStat(int accountId) {
//            var lessonStats = new LessonStat {
//                AccountId = accountId,
//                ExercisesSpeed = GenerateBaseLessonStat()
//            };
//            lessonStats.Id = Convert.ToInt32(lessonStats.Insert());
//            return lessonStats.ToDto();
//        }
        private Dictionary<int, int> GenerateBaseLessonExerciseStat(int lessonId) {
            var lessonExerciseNumber = new Lesson()
                .Select()
                .Where(Lesson.Fields.Id, PredicateCondition.Equal, lessonId)
                .GetData()
                .Single()
                .ToDto()
                .ExerciseNumber;
            var dict = new Dictionary<int, int>();
            for(var i = 0; i < lessonExerciseNumber; i++) {
                dict.Add(i, 60);
            }
            return dict;
        }
        private Dictionary<int, int> UpdateExercisesSpeedWithNewLesson(LessonStat lessonStat, int lessonId) {
            var newLessonStat = GenerateBaseLessonExerciseStat(lessonId);
            var newExercisesSpeed = UpdateExerciseSpeed(lessonStat.ExercisesSpeed, new Dictionary<int, Dictionary<int, int>> {{lessonId, newLessonStat}});
            new LessonStat()
                .Update()
                .Set(LessonStat.Fields.ExercisesSpeed, newExercisesSpeed)
                .Where(LessonStat.Fields.Id, PredicateCondition.Equal, lessonStat.Id)
                .ExecuteScalar();
            return newLessonStat;
        }
        public Dictionary<int, int> GetUsersLessonStat(int lessonId, int accountId) {
            var lessonStat = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .Single();
                var lessonStatDto = lessonStat.ToDto();
                return lessonStatDto.ExercisesSpeed.ContainsKey(lessonId)
                    ? lessonStatDto.ExercisesSpeed[lessonId]
                    : UpdateExercisesSpeedWithNewLesson(lessonStat, lessonId);
        }
        public void SaveUsersLessonStat(int accountId, int lessonId, Dictionary<int, int> lessonStat) {
            var lessonStatDto = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .Single();
            new LessonStat()
                .Select()
                .Update()
                .Set(LessonStat.Fields.ExercisesSpeed, UpdateExerciseSpeed(lessonStatDto.ExercisesSpeed, new Dictionary<int, Dictionary<int, int>>(){{lessonId, lessonStat}}))
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, lessonStatDto.AccountId)
                .ExecuteScalar();
        }
        public Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique() {
            var guitarTechnique = new GuitarTechnique()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
            var lessons = new Lesson()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
            return guitarTechnique.ToDictionary(gt => gt, gt => lessons
                .Where(l => l.GuitarTechniqueId == gt.Id)
                .OrderBy(l => l.OrderNumber)
                .ToList());
        }
        public LessonDto GetLesson(int lessonId) {
            return new Lesson()
                .Select()
                .Where(Lesson.Fields.Id, PredicateCondition.Equal, lessonId)
                .GetData()
                .Single()
                .ToDto();
        }
        public void CreateLessonStatNode(int accountId) {
            var lessonStat = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .SingleOrDefault();
            if(lessonStat == null) {
                new LessonStat {
                    AccountId = accountId
                }.Insert();
            }
        }
    }
}