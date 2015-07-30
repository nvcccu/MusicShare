namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        IUserProvider,
        ILogProvider,
        IDerzkieSchiProvider,
        IDesignerProvider,
        IAskProvider,
        IArticleProvider,
        IMarketProvider,
        ILessonProvider {
            void Initial();
    }
}