using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;

namespace BusinessLogic.Providers {
    public class DesignerProvider : IDesignerProvider {
        public List<ParameterDto> GetParameters() {
             return new Parameter()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
        }
        public List<ParameterValueDto> GetParameterValues() {
            return new ParameterValue()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
        }
        public List<IncompatibleParameterDto> GetIncompatibleParameters() {
            return new IncompatibleParameter()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
        }
        public List<DesignerImageTransportType> GetDesignerImages() {
            var images = new DesignerImage()
                .Select()
                .GetData()
                .ToList();
            var imagePositions = new DesignerImagePosition()
                .Select()
                .GetData()
                .ToList();
            return images.Select(i => new DesignerImageTransportType {
                DesignerImage = i.ToDto(),
                DesignerImagePositions = imagePositions
                    .Where(dip => dip.DesignerImageId == i.Id)
                    .Select(dip => dip.ToDto()).ToList()
            }).ToList();
        }
        public List<PredefinedGuitarDto> GetPredefinedGuitars() {
            return new PredefinedGuitar()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
        }
    }
}
