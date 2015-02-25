using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IDesignerProvider {
        List<ParameterDto> GetParameters();
        List<ParameterValueDto> GetParameterValues();
        List<IncompatibleParameterDto> GetIncompatibleParameters();
        List<DesignerImageTransportType> GetDesignerImages();
        List<PredefinedGuitarDto> GetPredefinedGuitars();
    }
}
