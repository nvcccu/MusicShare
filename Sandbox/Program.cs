using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using BusinessLogic.DaoEntities;

namespace Sandbox {
    // todo разобраться есть ли тут что-то полезное
    internal class Program {
         /// <summary>
        /// урл сайта
        /// </summary>
        private string SiteAddress { get; set; }

        /// <summary>
        /// куда пишем
        /// </summary>
        private string OutFileName { get; set; }

        public void Parse() {
            var categoryPattern = new Regex(@"<a href='\/(.+)'.+перейти к разделу (.+)' class.+</a>");
            var subcategoryPattern = new Regex("<a href=\"(\\/grid[0-9]+?)\"  class=\"LinksDown\">(.+?)<\\/a>");
            var request = (HttpWebRequest) WebRequest.Create(SiteAddress);
            request.ContentType = @"text/html; charset=windows-1251";
            var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.Default);
            var html = reader.ReadToEnd();
            var matches = categoryPattern.Matches(html);
            var categories = new Dictionary<string, string>();
            var subcategories = new Dictionary<string, string>();
            for (var i = 0; i < matches.Count; i++) {
                categories.Add(matches[i].Groups[2].ToString(), matches[i].Groups[1].ToString());
                Console.WriteLine(categories.Last().Key + "   " + categories.Last().Value);
            }
            Console.WriteLine("\n");
            foreach (var category in categories) {
                request = (HttpWebRequest)WebRequest.Create(SiteAddress + category.Value);
                reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.Default);
                html = reader.ReadToEnd();
                matches = subcategoryPattern.Matches(html);
                for (var i = 0; i < matches.Count; i++) {
                    if (!subcategories.ContainsKey(matches[i].Groups[2].ToString())) {
                        subcategories.Add(matches[i].Groups[2].ToString(), matches[i].Groups[1].ToString());
                    }
                    // Console.WriteLine(subcategories.Last().Key + "   " + subcategories.Last().Value + "\n");
                }
            }
        }

        public void Parse1() {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\Dynatone.xml");
            var brands = new Dictionary<int, string>();
            var products = new Dictionary<int, XmlNode>();
            var categoriesXml = xmlDoc.GetElementsByTagName("category");
            int guitars = 0;
            for (var i = 0; i < categoriesXml.Count; i++)
            {
                if (categoriesXml[i].InnerXml == "Электрогитары")
                {
                    guitars = Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText);
                }
            }
            for (var i = 0; i < categoriesXml.Count; i++)
            {
                var category = categoriesXml[i];
                if (category.Attributes.Count > 1 && Convert.ToInt32(category.Attributes["parentId"].InnerText) == guitars)
                {
                    brands.Add(Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText),
                        categoriesXml[i].InnerText);
                }
            }
            var productsXml = xmlDoc.GetElementsByTagName("offer");
            //            for (var i = 0; i < productsXml.Count; i++) {
            //                XmlNode productNode = productsXml[i];
            //                if (brands.ContainsKey(Convert.ToInt32(productNode["categoryId"].InnerText))) {
            //                    products.Add(Convert.ToInt32(productNode.Attributes["id"].InnerText), productNode);
            //                    var eg = new Guitar();
            //                    eg.Brand = brands[Convert.ToInt32(productNode["categoryId"].InnerText)];
            //                    eg.Model = productNode["name"].InnerText;
            //                    eg.Price = decimal.Parse(productNode["price"].InnerText, CultureInfo.InvariantCulture);
            //                    eg.Url = productNode["url"].InnerText;
            //                    eg.Save();
            //                }
            //            }
        }

        public void ParseDynatoneXml(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            var brands = new Dictionary<int, string>();
            var products = new Dictionary<int, XmlNode>();
            var categoriesXml = xmlDoc.GetElementsByTagName("category");
            int guitars = 0;
            for (var i = 0; i < categoriesXml.Count; i++)
            {
                if (categoriesXml[i].InnerXml == "Электрогитары")
                {
                    guitars = Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText);
                }
            }
            for (var i = 0; i < categoriesXml.Count; i++)
            {
                var category = categoriesXml[i];
                if (category.Attributes.Count > 1 &&
                    Convert.ToInt32(category.Attributes["parentId"].InnerText) == guitars)
                {
                    brands.Add(Convert.ToInt32(categoriesXml[i].Attributes["id"].InnerText),
                        categoriesXml[i].InnerText);
                }
            }
            var productsXml = xmlDoc.GetElementsByTagName("offer");
            for (var i = 0; i < productsXml.Count; i++)
            {
                XmlNode productNode = productsXml[i];
                if (brands.ContainsKey(Convert.ToInt32(productNode["categoryId"].InnerText)))
                {
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


        private static void Main(string[] args) {
            Console.ReadKey();
        }
    }
}