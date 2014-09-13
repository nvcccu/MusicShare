using System;
using System.Collections.Generic;
using System.Xml;

namespace BusinessLogic.Parser {
    public class DynatoneParser : ParserBase {
        private const string FILE_NAME = "D:\\Dynatone.xml";
        private string _xml;

        public override short GetBrand() {
            throw new NotImplementedException();
        }

        public short GetColor() {
            throw new NotImplementedException();
        }

        public short GetForm() {
            throw new NotImplementedException();
        }

        public string GetImage() {
            throw new NotImplementedException();
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
            var brands = new Dictionary<int, string>();
            var products = new Dictionary<int, XmlNode>();
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
                    Convert.ToInt32(category.Attributes["parentId"].InnerText) == guitars) {
                    brands.Add(Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText),
                        categoriesXml[i].InnerText);
                }
            }
            var productsXml = xmlDoc.GetElementsByTagName("offer");
            for (var i = 0; i < productsXml.Count; i++) {
                XmlNode productNode = productsXml[i];
                if (brands.ContainsKey(Convert.ToInt32(productNode["categoryId"].InnerText))) {
                    products.Add(Convert.ToInt32(productNode.Attributes["id"].InnerText), productNode);
                    //                    var eg = new Guitar();
                    //                    eg.Brand = brands[Convert.ToInt32(productNode["categoryId"].InnerText)];
                    //                    eg.Model = productNode["name"].InnerText;
                    //                    eg.Price = decimal.Parse(productNode["price"].InnerText, CultureInfo.InvariantCulture);
                    //                    eg.Url = productNode["url"].InnerText;
                    //                    eg.Save();
                }
            }
        }
    }
}
