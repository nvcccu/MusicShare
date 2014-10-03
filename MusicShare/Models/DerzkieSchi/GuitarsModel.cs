using System.Collections.Generic;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class GuitarsModel : GuitarTotalDataModel {
        public List<GuitarSummaryTransportType> GuitarsSummary { get; set; }

        public GuitarsModel() {
            GuitarsSummary = new List<GuitarSummaryTransportType>();
            var data = ServiceManager<IBusinessLogic>.Instance.Service.GetGuitarsSummary();
            foreach (var datum in data) {
                GuitarsSummary.Add(datum);
            }
        }
    }
}