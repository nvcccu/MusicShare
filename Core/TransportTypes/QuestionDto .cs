using System;

namespace Core.TransportTypes {
    public class QuestionDto {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AccountId { get; set; }
        public DateTime DateCreated { get; set; }
        public int WatchNumber { get; set; }
        public int VoteNumber { get; set; }
    }
}
