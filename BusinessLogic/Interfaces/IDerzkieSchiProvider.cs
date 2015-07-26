using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IDerzkieSchiProvider {
        Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties();
    }
}