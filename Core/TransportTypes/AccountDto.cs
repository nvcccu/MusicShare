using System;

namespace Core.TransportTypes {
    public class AccountDto {
        public int Id { get; set; }
        public long GuestId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
