namespace CommonUtils {
    public class ServiceManager<T> : ServiceManagerBase<ServiceManager<T>> where T : class {
        private T _service;

        public T Service {
            get {
                if (_service == null) {
                    lock (this) {
                        _service = Resolve<T>();
                    }
                }
                return _service;
            }
        }
    }
}