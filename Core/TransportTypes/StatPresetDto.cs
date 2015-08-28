using System.Collections.Generic;

namespace Core.TransportTypes {
    public class StatPresetDto {
        public int Id { get; set; }
        public int OwnerAccountId { get; set; }
        public string Name { get; set; }
        public List<int> Exercises { get; set; }
    }
}