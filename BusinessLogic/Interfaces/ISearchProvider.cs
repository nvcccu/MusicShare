using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ISearchProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="form"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        List<GuitarTransportType> Search(short brand, short form, short color);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        List<GuitarTransportType> GetSampleGuitars(short? brand, short? model, short? color);

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
        List<ColorTransportType> GetAllColor();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<NewsTransportType> GetLastNews();
    }
}