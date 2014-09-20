namespace BusinessLogic.Interfaces {
    public interface IUserProvider {
        long GetNextGuestId(string userAgent);
    }
}
