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
        private string UpdateExerciseSpeed(string exercisesSpeed, Dictionary<int, int> speedStat) {
            var ret = exercisesSpeed ?? String.Empty;
            const string RegexpPattern = "^{0}-\\d+|(?<=;){0}-\\d+";
            speedStat.ForEach(ss => {
                var regex = new Regex(String.Format(RegexpPattern, ss.Key));
                var tmp = ss.Key + "-" + ss.Value;
                if(regex.IsMatch(ret)) {
                    ret = regex.Replace(ret, tmp);
                } else {
                    ret += tmp + ";";
                }
            });
            return ret;
        }
        private Dictionary<int, int> GenerateBaseLessonExerciseStat(int lessonId) {
            var dict = new Dictionary<int, int>();
            var lessonExercises = new Exercise()
                .Select()
                .Where(Exercise.Fields.LessonId, PredicateCondition.Equal, lessonId)
                .GetData()
                .Select(e => e.ToDto())
                .ToList();
            lessonExercises.ForEach(e => dict.Add(e.Id, e.DefaultSpeed));
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
                .OrderBy(LessonStat.Fields.Id, OrderType.Desc)
                .GetData()
                .First();
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
        public void SaveUsersLessonStat(int accountId, Dictionary<int, int> lessonStat) {
            var now = DateTime.Today;
            var lessonStatDto = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .OrderBy(LessonStat.Fields.Id, OrderType.Desc)
                .GetData()
                .First();
            var exercisesSpeed = UpdateExerciseSpeed(lessonStatDto.ExercisesSpeed, lessonStat);
            if(now - lessonStatDto.Date > new TimeSpan(1, 0, 0)) {
                new LessonStat {
                    AccountId = accountId,
                    Date = now,
                    ExercisesSpeed = exercisesSpeed
                }
                .Insert();
            } else {
                new LessonStat()
                    .Select()
                    .Update()
                    .Set(LessonStat.Fields.ExercisesSpeed, exercisesSpeed)
                    .Where(LessonStat.Fields.Id, PredicateCondition.Equal, lessonStatDto.Id)
                    .ExecuteScalar();
            }
        }
        public Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique() {
            var guitarTechnique = new GuitarTechnique()
                .Select()
                .GetData()
                .Select(gt => gt.ToDto())
                .ToList();
            var lessons = new Lesson()
                .Select()
                .Where(Lesson.Fields.IsModerated, PredicateCondition.Equal, true)
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
        public LessonDto GetModeratedLesson(int lessonId) {
            return new Lesson()
                .Select()
                .Where(Lesson.Fields.Id, PredicateCondition.Equal, lessonId)
                .Where(Lesson.Fields.IsModerated, PredicateCondition.Equal, true)
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
                    AccountId = accountId,
                    Date = DateTime.Today
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
        public List<PlanDto> GetAllUsersPlans(int accountId) {
            return new Plan()
                .Select()
                .Where(Plan.Fields.OwnerAccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
        }
        public List<LessonDto> GetAllModeratedLessons() {
            return new Lesson()
                .Select()
                .Where(Lesson.Fields.IsModerated, PredicateCondition.Equal, true)
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
        public ExerciseDto GetExercise(int id) {
            return new Exercise()
                .Select()
                .Where(Exercise.Fields.Id, PredicateCondition.Equal, id)
                .GetData()
                .Single()
                .ToDto();
        }
        public List<ExerciseDto> GetExercisesByPlan(int planId) {
            var planExerciseIds = new Plan()
                .Select()
                .Where(Plan.Fields.Id, PredicateCondition.Equal, planId)
                .GetData()
                .Single()
                .ToDto()
                .ExerciseIds;
            var exercises = new Exercise()
                .Select()
                .Where(Exercise.Fields.Id, PredicateCondition.In, planExerciseIds)
                .GetData()
                .Select(e => e.ToDto())
                .ToList();
            return planExerciseIds.Select(i => exercises.Single(e => e.Id == i)).ToList();
        }
        public Dictionary<int, int> GetUsersExercisesStat(int accountId) {
            var exercises = new Exercise()
                .Select()
                .GetData()
                .Select(e => e.ToDto())
                .ToList();
            var exercisesSpeed = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .OrderBy(LessonStat.Fields.Id, OrderType.Desc)
                .GetData()
                .First()
                .ToDto()
                .ExercisesSpeed;
            if(exercisesSpeed.Keys.Count != exercises.Count) {
                var lessons = new Lesson()
                    .Select()
                    .GetData()
                    .Select(e => e.ToDto())
                    .ToList();
                var lessonStat = new LessonStat()
                    .Select()
                    .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                    .OrderBy(LessonStat.Fields.Id, OrderType.Desc)
                    .GetData()
                    .First();
                foreach(var lesson in lessons) {
                    var tmp = UpdateExercisesSpeedWithNewLesson(lessonStat, lesson.Id);
                    tmp.ForEach(t => {
                        if(!exercisesSpeed.ContainsKey(t.Key)) {
                            exercisesSpeed.Add(t.Key, t.Value);
                        }
                    });
                }
            }
            return exercisesSpeed;
        }
        public Dictionary<int, List<ExerciseSpeedInDate>> GetUsersExercisesTotalStat(int accountId) {
            var exercises = new Exercise()
                .Select()
                .GetData()
                .Select(e => e.ToDto())
                .ToList();
            var lessonStats = new LessonStat()
                .Select()
                .Where(LessonStat.Fields.AccountId, PredicateCondition.Equal, accountId)
                .OrderBy(LessonStat.Fields.Id, OrderType.Asc)
                .GetData()
                .Select(ls => ls.ToDto())
                .ToList();
            return exercises.ToDictionary(e => e.Id, e => lessonStats.Select(ls => new ExerciseSpeedInDate {
                Date = ls.Date,
                Speed = ls.ExercisesSpeed.ContainsKey(e.Id) ? ls.ExercisesSpeed[e.Id] : e.DefaultSpeed
            }).ToList());
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
        public void AddExerciseToPlan(int planId, int exerciseId) {
            var exerciseIds = new Plan()
                .Select()
                .Where(Plan.Fields.Id, PredicateCondition.Equal, planId)
                .GetData()
                .Single()
                .ToDto()
                .ExerciseIds;
            if(!exerciseIds.Contains(exerciseId)) {
                exerciseIds.Add(exerciseId);
            }
            new Plan()
                .Update()
                .Set(Plan.Fields.Exercises, SerializePlanExercises(exerciseIds))
                .Where(Plan.Fields.Id, PredicateCondition.Equal, planId)
                .ExecuteScalar();
        }
        public List<StatPresetDto> GetAllUsersStatPresets(int accountId) {
            return new StatPreset()
                .Select()
                .Where(StatPreset.Fields.OwnerAccountId, PredicateCondition.Equal, accountId)
                .GetData()
                .Select(sp => sp.ToDto())
                .ToList();
        }
        private string SerializeExercises(List<int> exercises) {
            return String.Join(";", exercises) + ";";
        }
        public StatPresetDto SaveStatPreset(StatPresetDto statPreset) {
            statPreset.Id = Convert.ToInt32(new StatPreset() {
                OwnerAccountId = statPreset.OwnerAccountId,
                Name = statPreset.Name,
                Exercises = SerializeExercises(statPreset.Exercises)
            }.Insert());
            return statPreset;
        }
        public bool UpdateStatPreset(StatPresetDto statPreset) {
            var tmp = new StatPreset()
                .Update();
            if(!String.IsNullOrEmpty(statPreset.Name)) {
                tmp = tmp.Set(StatPreset.Fields.Name, statPreset.Name);
            }
            if(statPreset.Exercises != null && statPreset.Exercises.Any()) {
                tmp = tmp.Set(StatPreset.Fields.Exercises, SerializeExercises(statPreset.Exercises));
            }
            tmp
                .Where(StatPreset.Fields.Id, PredicateCondition.Equal, statPreset.Id)
                .Where(StatPreset.Fields.OwnerAccountId, PredicateCondition.Equal, statPreset.OwnerAccountId)
                .ExecuteScalar();
            return true;
        }
        public bool DeleteStatPreset(int statPresetId) {
            new StatPreset()
                .Delete()
                .Where(StatPreset.Fields.Id, PredicateCondition.Equal, statPresetId)
                .ExecuteScalar();
            return true;
        }
        public bool SaveHomework(HomeworkDto homework) {
            new Homework {
                AccountId = homework.AccountId,
                LessonId = homework.LessonId,
                DateCreated = DateTime.Now,
                Link = homework.Link
            }.Insert();
            return true;
        }
    }
}