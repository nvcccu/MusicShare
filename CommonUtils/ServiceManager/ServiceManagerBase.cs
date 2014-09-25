using Castle.Windsor;
using CommonUtils.Patterns;

namespace CommonUtils.ServiceManager {
    public class ServiceManagerBase<T> : Singleton<T> where T : class, new() {
        public IWindsorContainer DependencyContainer { private get; set; }

        protected TR Resolve<TR>() {
            return DependencyContainer.Resolve<TR>();
        }
    }
}