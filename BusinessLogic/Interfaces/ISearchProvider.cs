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
        List<GuitarWithColorTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<GuitarSummaryTransportType> GetGuitarsSummary();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guitarSummary"></param>
        /// <returns></returns>
        bool SaveGuitarSummary(GuitarSummaryTransportType guitarSummary);

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
        List<ColorSimpleTransportType> GetAllSimpleColors();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ColorFullTransportType> GetAllFullColors();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<GuitarTransportType> GetAllGuitars();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<GuitarWithModelTransportType> GetAllGuitarsWithModel();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<NewsTransportType> GetLastNews();
    }
}