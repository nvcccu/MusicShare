using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Core.Enums;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class LessonProvider : ILessonProvider {
        private string UpdateExerciseSpeed(string exercisesSpeed, Dictionary<int, int> speedStat) {
            var ret = exercisesSpeed ?? String.Empty;
            speedStat.ForEach(ss => {
                var tmp = ss.Key + "-" + ss.Value;
                if(ret.IndexOf(ss.Key + "-", StringComparison.Ordinal) > -1) {
                    var regex = new Regex(ss.Key + "-" + "\\d+");
                    ret = regex.Replace(ret, tmp);
                } else {
                    ret += tmp + ";";
                }
            });
            return ret;
        }
        private Dictionary<int, int> GenerateBaseLessonExerciseStat(int lessonId) {
            var dict = new Dictionary<int, int>();
            var lessonExerciseIds = new Exercise()
                .Select()
                .Where(Exercise.Fields.LessonId, PredicateCondition.Equal, lessonId)
                .GetData()
                .Select(e => e.Id)
                .ToList();
            lessonExerciseIds.ForEach(id => dict.Add(id, 60));
            return dict;
        }
        private Dictionary<int, int> UpdateExercisesSpeedWithNewLesson(LessonStat lessonStat, int lessonId) {
            var newLessonStat = GenerateBaseLessonExerciseStat(lessonId);
            var newExercisesSpeed = UpdateExerciseSpeed(lessonStat.ExercisesSpeed, newLessonStat);
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
            var exerciseIds = new Exercise()
                .Select()
                .Where(Exercise.Fields.LessonId, PredicateCondition.Equal, lessonId)
                .GetData()
                .Select(e => e.Id)
                .ToList();
            var exercisesSpeedIds = lessonStatDto.ExercisesSpeed.Select(e => e.Key);
            return lessonStatDto.ExercisesSpeed.Count > 0 && exerciseIds.All(ei => exercisesSpeedIds.Contains(ei))
                ? lessonStatDto.ExercisesSpeed
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
                .Set(LessonStat.Fields.ExercisesSpeed, UpdateExerciseSpeed(lessonStatDto.ExercisesSpeed, lessonStat))
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
        public List<ExerciseDto> GetLessonExercises(int lessonId) {
            return new Exercise()
                .Select()
                .Where(Exercise.Fields.LessonId, PredicateCondition.Equal, lessonId)
                .GetData()
                .Select(e => e.ToDto())
                .ToList();
        }
        public GuitarTechniqueDto GetGuitarTechnique(int guitarTechniqueId) {
            return new GuitarTechnique()
                .Select()
                .Where(GuitarTechnique.Fields.Id, PredicateCondition.Equal, guitarTechniqueId)
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
        public void CreatePlanNode(int accountId) {
            var plan = new Plan()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .SingleOrDefault();
            if(plan == null) {
                new Plan {
                    OwnerAccountId = accountId
                }.Insert();
            }
        }
        public List<GuitarTechniqueDto> GetAllGuitarTechniques() {
            return new GuitarTechnique()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
        }
        public List<LessonDto> GetAllLessons() {
            return new Lesson()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
        }
        public List<ExerciseDto> GetAllExercises() {
            return new Exercise()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
        }
        public Dictionary<int, int> GetUsersExercisesStat(int accountId) {
            return new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .Single()
                .ToDto()
                .ExercisesSpeed;
        }
        public PlanDto GetPlan(int id) {
            return new Plan()
                .Select()
                .Where(Plan.Fields.Id, PredicateCondition.Equal, id)
                .GetData()
                .Single()
                .ToDto();
        }
        private string SerializePlanExercises(List<int> exerciseIds) {
            return String.Join(",", exerciseIds);
        }
        public int SavePlan(PlanDto plan) {
            return Convert.ToInt32(new Plan {
                OwnerAccountId = plan.OwnerAccountId,
                Name = plan.Name,
                Exercises = SerializePlanExercises(plan.ExerciseIds),
                Type = (int)plan.Type,
                IsPublic = plan.IsPublic
            }.Insert());
        }
        public void UpdatePlan(PlanDto plan) {
            new Plan()
                .Update()
                .Set(Plan.Fields.Name, plan.Name)
                .Set(Plan.Fields.Exercises, SerializePlanExercises(plan.ExerciseIds))
                .Set(Plan.Fields.Type, (int)plan.Type)
                .Set(Plan.Fields.IsPublic, plan.IsPublic)
                .Where(Plan.Fields.Id, PredicateCondition.Equal, plan.Id)
                .ExecuteScalar();
        }
    }
}