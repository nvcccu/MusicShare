namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        ISearchProvider,
        IUserProvider,
        ILogProvider,
        IDerzkieSchiProvider,
        IStoreProvider {
        void Initial();
    }
}