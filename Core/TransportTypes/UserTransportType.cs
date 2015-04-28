using System;

namespace Core.TransportTypes {
    public class UserTransportType {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}