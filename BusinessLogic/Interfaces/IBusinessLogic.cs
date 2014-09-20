namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        ISearchProvider,
        IUserProvider {
        void Initial();
    }
}