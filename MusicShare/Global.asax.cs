using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils;

namespace MusicShareWeb {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            var container = new WindsorContainer();
            container.Register(
                Component.For<IBusinessLogic>().LifestyleSingleton().Instance(new BusinessLogic.BusinessLogic()));
            ServiceManager<IBusinessLogic>.Instance.DependencyContainer = container;
        }

        private static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Search", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                "Error",
                "{controller}/{action}/{id}",
                new {controller = "Error", action = "NotFound", id = UrlParameter.Optional}
                );
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
//            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception ex = Server.GetLastError();
            if (ex is HttpException) {
                if (((HttpException) ex).GetHttpCode() == 404) {
                    Response.Redirect("Error/NotFound");
                } else {
                    Response.Redirect("Error/InternalError");
                }
            }
        }
    }
}