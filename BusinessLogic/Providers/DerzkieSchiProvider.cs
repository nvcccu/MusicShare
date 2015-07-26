using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class DerzkieSchiProvider : IDerzkieSchiProvider {
        public Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties() {
            var pruductTypes = new ProductType()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            var pruductProperties = new Property()
                .Select()
                .Where(Property.Fields.ProductTypeId, PredicateCondition.In, pruductTypes.Select(p => p.Id))
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            var propertyValues = new PropertyValue()
                .Select()
                .Where(PropertyValue.Fields.PropertyId, PredicateCondition.In, pruductProperties.Select(pp => pp.Id))
                .GetData()
                .Select(pv => pv.ToDto())
                .ToList();
            return pruductTypes.ToDictionary(p => p,
                p => pruductProperties
                    .Where(pp => pp.ProductTypeId == p.Id)
                    .ToDictionary(pp => pp,
                        pp => propertyValues
                            .Where(pv => pv.PropertyId == pp.Id).ToList()));
        }
        public int? SaveNewProduct(int productTypeId, Dictionary<int, int?> propertyValuePairs, string imageUrl, string name, int price) {
            int? id;
            id = Convert.ToInt32(new Product {
                ProductTypeId = productTypeId,
                ImageUrl = imageUrl,
                Name = name,
                Price = price
            }.Insert());
            foreach (var propertyValuePair in propertyValuePairs) {
                if (propertyValuePair.Value.HasValue) {
                    new ProductPropertyValue {
                        ProductId = id.Value,
                        PropertyId = propertyValuePair.Key,
                        PropertyValueId = propertyValuePair.Value
                    }.Insert();
                }
            }
            return id;
        }
    }
}