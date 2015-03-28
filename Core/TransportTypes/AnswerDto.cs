using System;

namespace Core.TransportTypes {
    public class AnswerDto {
        public long Id { get; set; }
        public int AccountId { get; set; }
        public long AnswerTo { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsSolution { get; set; }
        public int VoteNumber { get; set; }
    }
}
