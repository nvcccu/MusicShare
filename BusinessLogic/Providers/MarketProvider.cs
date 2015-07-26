using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class MarketProvider : IMarketProvider {
        public List<ProductTypeDto> GetAllProductTypes() {
            return new ProductType()
                .Select()
                .OrderBy(ProductType.Fields.Name, OrderType.Asc)
                .GetData()
                .Select(pt => pt.ToDto())
                .ToList();
        }
        public Dictionary<PropertyDto, List<PropertyValueDto>> GetAllProductProperties(long productType) {
            var pruductProperties = new Property()
                .Select()
                .Where(Property.Fields.ProductTypeId, PredicateCondition.Equal, productType)
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            var propertyValues = new PropertyValue()
                .Select()
                .Where(PropertyValue.Fields.PropertyId, PredicateCondition.In, pruductProperties.Select(pp => pp.Id))
                .GetData()
                .Select(pv => pv.ToDto())
                .ToList();
            return pruductProperties
                .ToDictionary(pp => pp, pp => propertyValues.Where(pv => pp.Id == pv.PropertyId).ToList());
        }
    }
}