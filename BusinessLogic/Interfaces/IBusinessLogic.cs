namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        ISearchProvider,
        IUserProvider,
        ILogProvider,
        IDerzkieSchiProvider,
        IStoreProvider,
        IDesignerProvider {
        void Initial();
    }
}