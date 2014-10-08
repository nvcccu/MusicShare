using System;
using System.Linq;
using System.Xml;
using BusinessLogic.DaoEntities;
using BusinessLogic.Helpers;
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
            var xmlDoc = ReadXml();
            var offersXml = xmlDoc.GetElementsByTagName("offer");
            for (var i = 0; i < offersXml.Count; i++) {
                try {
                    var offer = offersXml[i];
                    var idData = offer.Attributes["id"].InnerText;
                    var availableData = offer.Attributes["available"].InnerText;
                    var priceData = offer["price"];
                    var categoryIdData = offer["categoryId"];
                    var pictureData = offer["picture"];
                    var storeData = offer["store"];
                    var pickupData = offer["pickup"];
                    var deliveryData = offer["delivery"];
                    var nameData = offer["name"];
                    var descriptionData = offer["description"];

                    var id = idData != null ? Convert.ToInt32(idData) : -1;
                    var available = !string.IsNullOrEmpty(availableData) && Convert.ToBoolean(availableData);
                    var price = priceData != null ? Convert.ToInt32(priceData.InnerText) : -1;
                    var categoryId = categoryIdData != null ? Convert.ToInt32(categoryIdData.InnerText) : -1;
                    var picture = pictureData != null ? pictureData.InnerText : string.Empty;
                    var store = storeData != null && Convert.ToBoolean(storeData.InnerText);
                    var pickup = pickupData != null && Convert.ToBoolean(pickupData.InnerText);
                    var delivery = deliveryData != null && Convert.ToBoolean(deliveryData.InnerText);
                    var name = nameData != null ? nameData.InnerText : string.Empty;
                    var description = descriptionData != null ? descriptionData.InnerText : string.Empty;
                    if (!StoreHelper.Instance.AllOffers.Any(c => c.Id == id)) {
                        new Offer {
                            Id = id,
                            Available = available,
                            Price = price,
                            CategoryId = categoryId,
                            Picture = picture,
                            Store = store,
                            Pickup = pickup,
                            Delivery = delivery,
                            Name = name,
                            Description = description
                        }.Insert();
                    } else {
                        var curOffer = StoreHelper.Instance.AllOffers.First(c => c.Id == id);
                        if (curOffer.Available != available || curOffer.Price != price || curOffer.CategoryId != categoryId ||
                            curOffer.Picture != picture || curOffer.Store != store || curOffer.Pickup != pickup ||
                            curOffer.Delivery != delivery || curOffer.Name != name || curOffer.Description != description) {
                            new Offer()
                                .Update()
                                .Set(Offer.Fields.Available, available)
                                .Set(Offer.Fields.Price, price)
                                .Set(Offer.Fields.CategoryId, categoryId)
                                .Set(Offer.Fields.Picture, picture)
                                .Set(Offer.Fields.Store, store)
                                .Set(Offer.Fields.Pickup, pickup)
                                .Set(Offer.Fields.Delivery, delivery)
                                .Set(Offer.Fields.Name, name)
                                .Set(Offer.Fields.Description, description)
                                .ExecuteScalar();
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
        }

        public void Parse() {
            ParseCategory();
            ParseOffer();
        }
    }
}