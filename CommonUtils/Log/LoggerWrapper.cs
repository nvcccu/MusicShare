using System;

namespace CommonUtils.Log {
    public class LoggerWrapper {
        private static NLog.Logger _logger;

        public LoggerWrapper(string name) {
            _logger = NLog.LogManager.GetLogger(name);
        }
        public void Info(object message) {
            _logger.Info(message + Environment.NewLine);
        }
        public void Fatal(object message) {
            _logger.Fatal(message + Environment.NewLine);
        }
        public void Error(object message) {
            _logger.Error(message + Environment.NewLine);
        }
        public void Debug(object message) {
            _logger.Debug(message + Environment.NewLine);
        }
        public void Trace(object message) {
            _logger.Trace(message + Environment.NewLine);
        }
    }
}