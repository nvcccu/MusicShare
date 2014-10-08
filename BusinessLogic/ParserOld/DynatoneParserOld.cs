using System;
using System.Collections.Generic;
using System.Xml;
using BusinessLogic.Helpers;

namespace BusinessLogic.ParserOld {
    public class DynatoneParserOld : ParserBaseOld {
        private const string FILE_NAME = "D:\\Dynatone.xml";
        private string _xml;
        private readonly Dictionary<long, string> _brands = new Dictionary<long, string>();

        protected override int GetBrand(object obj)
        {
            var xml = (XmlNode)obj;
            var brandId = Convert.ToInt64(xml["categoryId"].InnerText);
//            foreach (var brand in BrandHelper.Brands) {
//                if (brandId == brand.Value) {
//                    return brand.Key;
//                }
//            }
            return -1;
        }

        protected override int GetColor(object obj)
        {
            var xml = (XmlNode)obj;
            var source = xml["name"].InnerText;
            var potentialColorStart = source.IndexOf("/", StringComparison.Ordinal);
            if (potentialColorStart > -1) {
                source = source.Substring(potentialColorStart);
            }
            foreach (var color in ColorHelper.Colors) {
                if (source.IndexOf(color.Value, StringComparison.OrdinalIgnoreCase) > -1) {
                    return color.Key;
                }
            }
            return -1;
        }

        /// <summary>
        /// так жить нельзя
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override int GetForm(object obj)
        {
            return -1;
        }

        protected override string GetImage(object obj) {
            var xml = (XmlNode)obj;
            return xml["picture"].InnerText;
        }

        protected override void GetData() {
            Parse();
        }

        /// <summary>
        /// получает данные откуда-то там
        /// </summary>
        public void GetSource() {
            _xml = "D:\\Dynatone.xml";
        }

        public void Parse() {
            GetSource();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\Dynatone.xml");
            var categoriesXml = xmlDoc.GetElementsByTagName("category");
            int guitars = 0;
            for (var i = 0; i < categoriesXml.Count; i++) {
                if (categoriesXml[i].InnerXml == "Электрогитары") {
                    guitars = Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText);
                }
            }
            for (var i = 0; i < categoriesXml.Count; i++) {
                var category = categoriesXml[i];
                if (category.Attributes.Count > 1 &&
                    Convert.ToInt64(category.Attributes["parentId"].InnerText) == guitars) {
                    _brands.Add(Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText),
                        categoriesXml[i].InnerText);
                }
            }
            var productsXml = xmlDoc.GetElementsByTagName("offer");
            for (var i = 0; i < productsXml.Count; i++) {
                XmlNode productNode = productsXml[i];
                if (_brands.ContainsKey(Convert.ToInt64(productNode["categoryId"].InnerText))) {
                    Items.Add(productNode);
                }
            }
        }
    }
}
