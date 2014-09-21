using System.Web.Mvc;
using BusinessLogic.Interfaces;
using CommonUtils;
using Core.Enums;

namespace MusicShareWeb.Controllers {
    public class LogController : BaseController {
        [HttpPost]
        public void LogAction(long guestId, ActionId actionId, long? target) {
            ServiceManager<IBusinessLogic>.Instance.Service.AddUserAction(guestId, actionId, target);
        }
    }
}