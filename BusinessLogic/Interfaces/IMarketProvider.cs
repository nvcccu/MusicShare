using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IMarketProvider {
        List<ProductTypeDto> GetAllProductTypes();
        Dictionary<PropertyDto, List<PropertyValueDto>> GetAllProductProperties(long productType);
    }
}
