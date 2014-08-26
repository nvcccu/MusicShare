using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ISearchProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        List<GuitarTransportType> Search(string brand, string model, string color);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        GuitarTransportType GetSampleGuitar(string brand, string model, string color);

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
    }
}