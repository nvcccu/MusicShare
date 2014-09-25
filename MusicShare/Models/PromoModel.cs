using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using BusinessLogic.Interfaces;
using CommonUtils;

namespace MusicShareWeb.Models
{
    public class PromoModel : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<NewsTransportType> News { get; private set; }

        public PromoModel()
        {
            News = ServiceManager<IBusinessLogic>.Instance.Service.GetLastNews();
        }
    }
}