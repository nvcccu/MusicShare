using System;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Plan : AbstractEntity<Plan> {
        public Plan(string tableName) : base(tableName) {}

        public Plan() : base("Plan") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof(Int32))]
            OwnerAccountId,
            [DbType(typeof (String))]
            Name,
            [DbType(typeof (String))]
            Exercises,
            [DbType(typeof (Int32))]
            Type,
            [DbType(typeof (Boolean))]
            IsPublic
        }

        public int Id { get; set; }
        public int OwnerAccountId { get; set; }
        public string Name { get; set; }
        public string Exercises { get; set; }
        public int Type { get; set; }
        public bool IsPublic { get; set; }

        private List<int> ParseExercises() {
            return Exercises.Split(',').Select(e => Convert.ToInt32(e)).ToList();
        }

        public PlanDto ToDto() {
            return new PlanDto {
                Id = Id,
                OwnerAccountId = OwnerAccountId,
                Name = Name,
                ExerciseIds = ParseExercises(),
                Type = (PlanType)Type,
                IsPublic = IsPublic
            };
        }
    }
}