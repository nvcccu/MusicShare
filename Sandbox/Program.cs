﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils.Config;
using CommonUtils.ServiceManager;
using Core.Enums;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;
using DAO.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            //                    eg.ModelId = productNode["name"].InnerText;
            //                    eg.Price = decimal.Parse(productNode["price"].InnerText, CultureInfo.InvariantCulture);
            //                    eg.Url = productNode["url"].InnerText;
            //                    eg.Insert();
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
//                    eg.ModelId = productNode["name"].InnerText;
//                    eg.Price = decimal.Parse(productNode["price"].InnerText, CultureInfo.InvariantCulture);
//                    eg.Url = productNode["url"].InnerText;
//                    eg.Insert();
                }
            }
        }
        private static void AddWhereIfNotNull<T>(AbstractEntity<T> ds, Enum field, PredicateCondition oper, object value)
           where T : new()
        {
            if (value != null)
            {
                ds.Where(field, oper, value);
            }
        }

//        private static void A() {
//            var strs = File.ReadAllLines(@"d:\cat1.txt");
//            foreach (var str in strs) {
//                var pair = str.Split(',');
//                new OfferCategory {
//                    Id = Convert.ToInt64(pair.First()),
//                    ParentId = Convert.ToInt64(pair.Last())
//                }.Save();
//            }
//        }
//
//        private static void B() {
//            var strs = File.ReadAllLines(@"d:\cat2.txt");
//            foreach (var str in strs) {
//                var pair = str.Split(',');
//                new OfferCategory()
//                    .Update()
//                    .Set(OfferCategory.Fields.Name, pair.Last())
//                    .Where(OfferCategory.Fields.Id, PredicateCondition.Equal, Convert.ToInt64(pair.First()))
//                    .ExecuteScalar();
//            }
//        }
//       

        public class OfferCategory : AbstractEntity<OfferCategory> {
        public OfferCategory(string tableName) : base(tableName) {}

        public OfferCategory() : base("OfferCategory") {}

        public enum Fields {
            [DbType(typeof (Int64))]
            Id,
            [DbType(typeof (Int64))]
            ParentId
        }

        public long Id { get; set; }
        public long ParentId { get; set; }
    }

        private static void Main(string[] args) {
        

            // НЕ УДАЛЯТЬ
            ConfigHelper.LoadXml(true);
            Connector.ConnectionString = ConfigHelper.FirstTagWithTagNameInnerText("db-connection");
            // НЕ УДАЛЯТЬ
            
            var qqqqq = new Article()
                .Select()
                .Where(Article.Fields.Id, PredicateCondition.Equal, 2)
                .Where(Article.Fields.IsModerated, PredicateCondition.Equal, true)
                .GetData()
                .Single()
                .ToDto();
         
            Console.WriteLine("end");
            Console.ReadKey();
            return;

          




//            new Brand()
//                .Update()
//                .Set(Brand.Fields.Logo, "newLogo")
//                .Set(Brand.Fields.Name, "newName")
//                .Where(Brand.Fields.Id, PredicateCondition.Equal, 3825)
//                .ExecuteScalar();



//            var sample = new GuitarWithColor()
//                .Select()
//                .InnerJoin(new ColorFull(), RetrieveMode.NonRetrieve)
//                .On(GuitarWithColor.Fields.ColorFullId, PredicateCondition.Equal, ColorFull.Fields.Id)
//                .InnerJoin(new ColorSimple(), RetrieveMode.NonRetrieve)
//                .On(ColorFull.Fields.ColorSimpleId, PredicateCondition.Equal, ColorSimple.Fields.Id)
//                .InnerJoin(new Guitar(), RetrieveMode.NonRetrieve)
//                .On(GuitarWithColor.Fields.GuitarWithColorId, PredicateCondition.Equal, Guitar.Fields.Id)
//                .InnerJoin(new Brand(), RetrieveMode.NonRetrieve)
//                .On(Guitar.Fields.BrandId, PredicateCondition.Equal, Brand.Fields.Id)
//                .InnerJoin(new Form(), RetrieveMode.NonRetrieve)
//                .GetData()
//                .ToList();

//            new JoinCondition {
//                        FieldFrom = Guitar.Fields.BrandId,
//                        FieldTarget = Brand.Fields.Id,
//                        Oper = PredicateCondition.Equal
//                    })

            var q = 1;
            var p = ++q;
            var w = 1;
            var container = new WindsorContainer();
            container.Register(
                Component.For<IBusinessLogic>().LifestyleSingleton().Instance(new BusinessLogic.BusinessLogic()));
            ServiceManager<IBusinessLogic>.Instance.DependencyContainer = container;
            ServiceManager<IBusinessLogic>.Instance.Service.AddUserAction(1, ActionId.OpenSearch);
            ServiceManager<IBusinessLogic>.Instance.Service.AddUserAction(1, ActionId.OpenSearch, 2);
            Console.ReadKey();

        }
    }
} 