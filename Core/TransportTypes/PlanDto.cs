using System.Collections.Generic;
using Core.Enums;

namespace Core.TransportTypes {
    public class PlanDto {
        public int Id { get; set; }
        public int OwnerAccountId { get; set; }
        public string Name { get; set; }
        public List<int> ExerciseIds { get; set; }
        public PlanType Type { get; set; }
        public bool IsPublic { get; set; }
    }
}