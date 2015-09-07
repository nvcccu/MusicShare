using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IDerzkieSchiProvider {
        Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties();
        int? SaveNewProduct(int productTypeId, Dictionary<int, int?> propertyValuePairs, string imageUrl, string name, int price);
        List<ProductDto> GetFilteredProducts(int productTypeId, string namePart, Dictionary<int, int> propertyValuePairs);
        bool UpdateLesson(LessonDto lesson);
        int CreateLesson(LessonDto lesson);
    }
}