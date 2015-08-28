using System;
using System.Collections.Generic;
using System.Linq;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class StatPreset : AbstractEntity<StatPreset> {
        public StatPreset(string tableName) : base(tableName) {}

        public StatPreset() : base("StatPreset") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            OwnerAccountId,
            [DbType(typeof(String))]
            Name,
            [DbType(typeof(String))]
            Exercises
        }

        public int Id { get; set; }
        public int OwnerAccountId { get; set; }
        public string Name { get; set; }
        public string Exercises { get; set; }

        private List<int> ParseExercises() {
            return Exercises.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).Select(parsed => Convert.ToInt32(parsed)).ToList();
        } 

        public StatPresetDto ToDto() {
            return new StatPresetDto {
                Id = Id,
                OwnerAccountId = OwnerAccountId,
                Name = Name,
                Exercises = ParseExercises()
            };
        }
    }
}