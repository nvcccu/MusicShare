using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ISearchProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="formId"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        List<GuitarTransportType> Search(int brand, int formId, int color);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="formId"></param>
        /// <param name="simpleColorId"></param>
        /// <returns></returns>
        List<GuitarTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<SearchHintTransportType> GetSearchHints();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<BrandTransportType> GetAllBrand();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<FormTransportType> GetAllForm();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ColorSimpleTransportType> GetAllColor();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<NewsTransportType> GetLastNews();
    }
}