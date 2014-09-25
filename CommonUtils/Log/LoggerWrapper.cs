namespace CommonUtils.Log {
    public class LoggerWrapper {
        private static NLog.Logger _logger;

        public LoggerWrapper(string name) {
            _logger = NLog.LogManager.GetLogger(name);
        }

        public void Info(object message) {
            _logger.Info(message.ToString());
        }

        public void Fatal(string message) {
            _logger.Fatal(message);
        }
    }
}