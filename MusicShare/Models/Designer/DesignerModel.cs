using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;

namespace MusicShareWeb.Models {
    public class DesignerModel : BaseModel {
        public FormParameter FormParameter { get; set; }
        public BridgeParameter BridgeParameter { get; set; }

        public DesignerModel() {
            FormParameter = new FormParameter {
                Name = "корпус",
                Forms = ServiceManager<IBusinessLogic>.Instance.Service.GetAllForms(),
                Colors = ServiceManager<IBusinessLogic>.Instance.Service.GetAllColors(),
                FormsWithColor = ServiceManager<IBusinessLogic>.Instance.Service.GetAllFormsWithColor(),
            };
            BridgeParameter = new BridgeParameter {
                Name = "бриджа",
                Bridges = ServiceManager<IBusinessLogic>.Instance.Service.GetAllBridges()
            };
        }
    }
}