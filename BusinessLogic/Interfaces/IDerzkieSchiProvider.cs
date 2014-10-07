using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IDerzkieSchiProvider {
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
        /// <param name="guitarSummary"></param>
        /// <returns></returns>
        bool SaveNewGuitar(GuitarSummaryTransportType guitarSummary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guitarModel"></param>
        /// <returns></returns>
        bool UpdateGuitarModel(GuitarWithModelTransportType guitarModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guitarModel"></param>
        /// <returns></returns>
        bool SaveNewGuitarModel(GuitarWithModelTransportType guitarModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guitarColor"></param>
        /// <returns></returns>
        bool UpdateGuitarColor(GuitarWithColorTransportType guitarColor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guitarColor"></param>
        /// <returns></returns>
        bool SaveNewGuitarColor(GuitarWithColorTransportType guitarColor);
    }
}