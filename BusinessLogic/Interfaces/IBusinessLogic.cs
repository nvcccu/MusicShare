﻿namespace BusinessLogic.Interfaces {
    public interface IBusinessLogic :
        ISearchProvider,
        IUserProvider,
        ILogProvider,
        IDerzkieSchiProvider {
        void Initial();
    }
}