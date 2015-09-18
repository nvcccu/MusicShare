using System;

namespace Core.TransportTypes {
    public class UserActionLogDto {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public int ActionId { get; set; }
        public long? Target { get; set; }
        public DateTime Date { get; set; }
    }
}