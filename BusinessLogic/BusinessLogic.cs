using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using BusinessLogic.DaoEntities;
using BusinessLogic.Providers;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic{
        public BusinessLogic() {}

        public void ParseDynatoneXml(string filename) {
            return;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
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
                    var eg = new ElectronicGuitar();
                    eg.Brand = brands[Convert.ToInt32(productNode["categoryId"].InnerText)];
                    eg.Model = productNode["name"].InnerText;
                    eg.Price = decimal.Parse(productNode["price"].InnerText, CultureInfo.InvariantCulture);
                    eg.Url = productNode["url"].InnerText;
                    eg.Save();
                }
            }
        }

        public void Initial() {
            throw new NotImplementedException();
        }
    }

    public interface IBusinessLogic : ISearchProvider {
        void Initial();
    }
}
