using System;
using System.Threading;
using NLog;

namespace CommonUtils.TaskSheduler {
    public abstract class TaskShedulerBase {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private int _timeout;
        private readonly object _workLock = new object();
        private bool _isNeedWork;
        private bool _isWorking;
        protected static DateTime? LastStart;
        private readonly Action _action;
        private readonly Func<bool> _isNeedWorkCheckAction;

        protected TaskShedulerBase(Action action, Func<bool> isNeedWorkCheckAction) {
            _action = action;
            _isNeedWorkCheckAction = isNeedWorkCheckAction;
            _timeout = 5*1000;
            var thread = new Thread(Loop);
            thread.Start();
        }

        private void Do() {
            if (!_isWorking) {
                lock (_workLock) {
                    if (!_isWorking) {
                        _isWorking = true;
                        _action();
                        _isWorking = false;
                    }
                }
            }
        }

        private void CheckIsNeedWork() {
            _isNeedWork = _isNeedWorkCheckAction();
        }

        public void Loop() {
            Console.WriteLine("threadId = {0}; ");
            while (true) {
                CheckIsNeedWork();
                if (_isNeedWork) {
                    Do();
                    LastStart = DateTime.Now;
                }
                Thread.Sleep(_timeout);
            }
        }
    }

    public class TaskShedulerByInterval : TaskShedulerBase {
        public TaskShedulerByInterval(Action action, TimeSpan period) : base(action, () => {
            if (LastStart == null) {
                LastStart = DateTime.Now;
                return true;
            }
            return (DateTime.Now - LastStart) > period;
        }) { }
    }

    public class TaskShedulerSingleByDay : TaskShedulerBase {
        public TaskShedulerSingleByDay(Action action, DateTime startDate) : base(action, () => (DateTime.Now - startDate) > new TimeSpan(1, 0, 0, 0)) { }
    }
}