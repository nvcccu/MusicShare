using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IAuthProvider {
        bool SignUp(AuthTransportType auth);
        bool Login(AuthTransportType auth);
    }
}