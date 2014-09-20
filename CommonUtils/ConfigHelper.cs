using System;
using System.Xml;

namespace CommonUtils {
    /// <summary>
    /// гнилой класс для неправильной работы с конфигами
    /// </summary>
    public static class ConfigHelper {
        private static readonly XmlDocument _configXml;
        private static string _configPath;

        static ConfigHelper() {
            _configXml = new XmlDocument();
        }

        public static void LoadXml(bool isTest) {
            _configPath = isTest
                ? "D:\\Projects\\MusicShare\\Config\\Test.xml"
                : "D:\\Projects\\MusicShare\\Config\\Master.xml";
            _configXml.Load(_configPath);
        }

        /// <summary>
        /// накостыленное обращение к конфигам
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [Obsolete("Временное решение, ибо агила")]
        public static string FirstTagWithPropertyText(string tagName, string attributeName, string attributeValue) {
            if (_configXml.InnerText == null) {
                throw new Exception("Не указан конфиг для чтения");
            }
            return _configXml.GetElementsByTagName(tagName)[0].InnerText;
        }
    }
}
