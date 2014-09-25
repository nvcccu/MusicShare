using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Log
{
    public class LoggerManager {
        private static Dictionary<string, LoggerWrapper> _loggers = new Dictionary<string, LoggerWrapper>();
        private static object _lock = new object();

        public static LoggerWrapper GetLogger(string name) {
            LoggerWrapper logger;
            if (!_loggers.TryGetValue(name, out logger)) {
                lock (_lock) {
                    if (!_loggers.TryGetValue(name, out logger)) {
                        logger = new LoggerWrapper(name);
                        _loggers.Add(name, logger);
                    }
                }
            }
            return logger;
        }
    }
}
