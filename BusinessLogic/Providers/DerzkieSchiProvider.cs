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
    }
}