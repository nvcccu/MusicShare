using System;
using System.Linq;
using System.Xml;
using BusinessLogic.DaoEntities;
using BusinessLogic.Helpers;
using Castle.Core.Internal;
using DAO.Enums;

namespace BusinessLogic.Parser {
    public class DynatoneParser {
        private XmlDocument ReadXml() {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\Dynatone.xml");
            return xmlDoc;
        }

        private void ParseCategory() {
            var xmlDoc = ReadXml();
            var categoriesXml = xmlDoc.GetElementsByTagName("category");
            for (var i = 0; i < categoriesXml.Count; i++) {
                var category = categoriesXml[i];
                if (category.Attributes != null) {
                    long id = Convert.ToInt64(category.Attributes["id"].InnerText);
                    if (!StoreHelper.Instance.AllOfferCategories.Any(c => c.Id == id)) {
                        var parentIdAttr = (category.Attributes["parentId"] != null)
                            ? category.Attributes["parentId"].InnerText
                            : string.Empty;
                        long? parentId = null;
                        if (!string.IsNullOrEmpty(parentIdAttr)) {
                            parentId = Convert.ToInt64(parentIdAttr);
                        }
                        new OfferCategory {
                            Id = id,
                            ParentId = parentId,
                            Name = category.InnerText
                        }.Insert();
                    } else {
                        var curCategory = StoreHelper.Instance.AllOfferCategories.First(c => c.Id == id);
                        var parentIdAttr = (category.Attributes["parentId"] != null)
                            ? category.Attributes["parentId"].InnerText
                            : string.Empty;
                        long? parentId = null;
                        if (!string.IsNullOrEmpty(parentIdAttr)) {
                            parentId = Convert.ToInt64(parentIdAttr);
                        }
                        var name = category.InnerText;
                        if (curCategory.ParentId != parentId
                            || curCategory.Name != name) {
                            new OfferCategory()
                                .Update()
                                .Set(OfferCategory.Fields.ParentId, parentId)
                                .Set(OfferCategory.Fields.Name, name)
                                .Where(OfferCategory.Fields.Id, PredicateCondition.Equal, id)
                                .ExecuteScalar();
                        }
                    }
                }
            }
        }

        private void ParseOffer() {
            
        }

        public void Parse() {
            ParseCategory();
            ParseOffer();
        }
    }
}