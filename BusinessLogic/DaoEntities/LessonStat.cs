using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class LessonStat : AbstractEntity<LessonStat> {
        public LessonStat(string tableName) : base(tableName) {}

        public LessonStat() : base("LessonStat") { }

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            AccountId,
            [DbType(typeof (String))]
            ExercisesSpeed
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ExercisesSpeed { get; set; }

        private Dictionary<int, Dictionary<int, int>> ParseExerciseSpeed() {
            var parsed = new Dictionary<int, Dictionary<int, int>>();
            if(!String.IsNullOrEmpty(ExercisesSpeed)) {
                var parsedByLesson = ExercisesSpeed.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);
                parsedByLesson.ForEach(p => {
                    var splitedLesson = p.Split(':');
                    var lessonId = Convert.ToInt32(splitedLesson[0]);
                    var exerciseData = splitedLesson[1];
                    var parsedByExercise = exerciseData.Split(',');
                    parsed.Add(lessonId, parsedByExercise.ToDictionary(pbe => Convert.ToInt32(pbe.Split('-')[0]), pbe => Convert.ToInt32(pbe.Split('-')[1])));
                });
            }
            return parsed;
        }

        public LessonStatDto ToDto() {
            return new LessonStatDto {
                Id = Id,
                AccountId = AccountId,
                ExercisesSpeed = ParseExerciseSpeed()
            };
        }
    }
}