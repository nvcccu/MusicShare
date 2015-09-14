using System;
using System.IO;
using System.Xml;

namespace CommonUtils.Config {
    /// <summary>
    /// гнилой класс для неправильной работы с конфигами
    /// </summary>
    public static class ConfigHelper {
        private static readonly XmlDocument _remotingMainConfig;
        private static string _configPath;

        static ConfigHelper() {
            _remotingMainConfig = new XmlDocument();
        }

        public static void LoadXml(bool isTest) {
            var _remotingConfigPath = Environment.GetEnvironmentVariable("mg_config");
            if (string.IsNullOrEmpty(_remotingConfigPath)) {
                throw new Exception("Не указан путь до конфигов проекта.");
            }
            if (isTest) {
                _remotingConfigPath = Path.Combine(_remotingConfigPath, "Test");
            }
            _remotingConfigPath = Path.Combine(_remotingConfigPath, "Remoting.xml");
            _remotingConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _remotingConfigPath.TrimStart('\\'));
            var remotingConfig = new XmlDocument();
            remotingConfig.Load(_remotingConfigPath);
            var remotingMainConfigPath = remotingConfig.FirstTagWithTagNameInnerText("path");
            remotingMainConfigPath = Path.Combine(remotingMainConfigPath, "RemotingMain.xml");
            remotingMainConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, remotingMainConfigPath.TrimStart('\\'));
            _remotingMainConfig.Load(remotingMainConfigPath);
            if (_remotingMainConfig.InnerText == null) {
                throw new Exception("Конфигурационный файл пуст или не прочитан.");
            }
        }

        [Obsolete("Временное решение, ибо агила")]
        public static string FirstTagWithTagNameInnerText(string tagName) {
//            try {
                return _remotingMainConfig.GetElementsByTagName(tagName)[0].InnerText;
//            } catch (Exception ex) {
//                // todo: log here
//            }
        }

        [Obsolete("Временное решение, ибо агила")]
        private static string FirstTagWithTagNameInnerText(this XmlDocument xmlDocument, string tagName) {
//            try {
                return xmlDocument.GetElementsByTagName(tagName)[0].InnerText;
//            } catch (Exception ex) {
//                // todo: log here
//            }
        }
    }
}
