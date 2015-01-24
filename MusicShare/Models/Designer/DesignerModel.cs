using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Models {
    public class IncompatibleParameterModel {
        public int ParameterId { get; set; }
        public int ParameterValueId { get; set; } 
    }
    public class ParameterValueModel {
        public int Id { get; set; }
        public string ImagePreviewUrl { get; set; }
        public List<IncompatibleParameterModel> IncompatibleParameters { get; set; }
    }
    public class ParameterModel {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string NameNominative { get; set; }
        public string NameGenitive { get; set; }
        public List<ParameterValueModel> ParameterValues { get; set; }
    }
    public class DesignerImagePositionModel {
        public Dictionary<int, int> Parameters { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class DesignerImageModel {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<DesignerImagePositionModel> Position { get; set; }
    }
    public class DesignerModel : BaseModel {
        List<ParameterModel> Parameters { get; set; }
        List<DesignerImageModel> DesignerImages { get; set; }

        public DesignerModel() {
            var parameters = ServiceManager<IBusinessLogic>.Instance.Service.GetParameters();
            var parameterValues = ServiceManager<IBusinessLogic>.Instance.Service.GetParameterValues();
            var incompatibleParameters = ServiceManager<IBusinessLogic>.Instance.Service.GetIncompatibleParameters();
            var designerImages = ServiceManager<IBusinessLogic>.Instance.Service.GetDesignerImages();
            Parameters = parameters.Select(p => new ParameterModel {
                Id = p.Id,
                ParentId = p.ParentId,
                NameNominative = p.NameNominative,
                NameGenitive = p.NameGenitive,
                ParameterValues = parameterValues.Where(pv => pv.ParameterId == p.Id).ToList().Select(pv => new ParameterValueModel {
                    Id = pv.Id,
                    ImagePreviewUrl = pv.ImagePreviewUrl,
                    IncompatibleParameters = incompatibleParameters
                        .Where(ip => ip.ParameterId == p.Id && ip.ParameterValueId == pv.Id)
                        .Select(ip => new IncompatibleParameterModel {
                            ParameterId = ip.IncompatibleParameterId,
                            ParameterValueId = ip.IncompatibleParameterValueId
                    }).ToList()
                }).ToList()
            }).ToList();
            DesignerImages = designerImages.Select(di => new DesignerImageModel {
                Id = di.Id,
                Url = di.Url,
                Position = di.DesignerImagePositions.Select(dip => new DesignerImagePositionModel {
                    Parameters = dip.Parameters,
                    X = dip.X,
                    Y = dip.Y
                }).ToList()
            }).ToList();
        }
    }
}