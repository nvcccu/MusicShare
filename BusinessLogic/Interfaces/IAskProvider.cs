using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IAskProvider {
        AskThreadTransportType GetAskThread(long questionId);
    }
}
