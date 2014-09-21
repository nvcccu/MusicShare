namespace Core.TransportTypes {
    public class UserActionLogTransportType {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public int ActionId { get; set; }
        public long? Target { get; set; }
    }
}