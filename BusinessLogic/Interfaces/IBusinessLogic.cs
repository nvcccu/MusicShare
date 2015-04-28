namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        IUserProvider,
        ILogProvider,
        IDerzkieSchiProvider,
        IDesignerProvider,
        IAskProvider,
        IAuthProvider{
            void Initial();
    }
}