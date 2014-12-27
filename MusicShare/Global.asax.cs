using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils.Log;
using CommonUtils.ServiceManager;

namespace MusicShareWeb {
    public class ExampleRoute : RouteBase {
        public override RouteData GetRouteData(HttpContextBase httpContext) {
            var url = httpContext.Request.Headers["HOST"];
            var index = url.IndexOf(".");

            if (index < 0) {
                return null;
            }

            var subDomain = url.Substring(0, index);

            if (subDomain == "user1") {
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Placard"); //Goes to the User1Controller class
                routeData.Values.Add("action", "Index"); //Goes to the Index action on the User1Controller

                return routeData;
            }

            if (subDomain == "user2") {
                var routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Forum"); //Goes to the User2Controller class
                routeData.Values.Add("action", "Index"); //Goes to the Index action on the User2Controller

                return routeData;
            }

            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
            //Implement your formating Url formating here
            return null;
        }
    }

    internal class SubdomainRoute : Route {
        public SubdomainRoute(string url) : base(url, new MvcRouteHandler()) {}

        public override RouteData GetRouteData(HttpContextBase httpContext) {
            var routeData = base.GetRouteData(httpContext);
            if (routeData == null) {
                return null; // Only look at the subdomain if this route matches in the first place.
            }
            string subdomain = httpContext.Request.Params["subdomain"];
                // A subdomain specified as a query parameter takes precedence over the hostname.
            if (subdomain == null) {
                string host = httpContext.Request.Headers["Host"];
                int index = host.IndexOf('.');
                if (index >= 0) {
                    subdomain = host.Substring(0, index);
                }
            }
            if (subdomain != null) {
                routeData.Values["subdomain"] = subdomain;
            }
            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
            object subdomainParam = requestContext.HttpContext.Request.Params["subdomain"];
            if (subdomainParam != null) {
                values["subdomain"] = subdomainParam;
            }
            return base.GetVirtualPath(requestContext, values);
        }
    }

    public class MvcApplication : HttpApplication {
        private static readonly LoggerWrapper _logger = LoggerManager.GetLogger(typeof (MvcApplication).FullName);

        protected void Application_Start() {
            _logger.Info("Application start");
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            var routes = RouteTable.Routes;
            routes.Add(new ExampleRoute());
            RegisterRoutes(routes);
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
            _logger.Info(ex);
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