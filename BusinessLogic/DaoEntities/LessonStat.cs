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

        private Dictionary<int, int> ParseExerciseSpeed() {
            var parsed = new Dictionary<int, int>();
            if(!String.IsNullOrEmpty(ExercisesSpeed)) {
                var parsedByExercise = ExercisesSpeed.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);
                parsedByExercise.ForEach(e => {
                    var splitedExercise = e.Split('-');
                    parsed.Add(Convert.ToInt32(splitedExercise[0]), Convert.ToInt32(splitedExercise[1]));
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