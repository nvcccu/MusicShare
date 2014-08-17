﻿namespace CommonUtils {
    public class Singleton<T> where T : class, new() {
        private static T _instance;
        private static readonly object _lock = new object();
 
        public static T Instance {
            get {
                if (_instance == null) {
                    lock (_lock) {
                        _instance = _instance ?? new T();
                    }
                }
                return _instance;
            }
        }
    }
}