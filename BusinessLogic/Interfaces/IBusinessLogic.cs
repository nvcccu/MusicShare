namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        ISearchProvider,
        IUserProvider,
        ILogProvider {
        void Initial();
    }
}