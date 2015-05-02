﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils.Log;
using CommonUtils.ServiceManager;

namespace MusicShareWeb {
  public class MvcApplication : HttpApplication {
        private static readonly LoggerWrapper _logger = LoggerManager.GetLogger(typeof (MvcApplication).FullName);

        protected void Application_Start() {
            _logger.Info("Application start");
            AreaRegistration.RegisterAllAreas();
          
            var routes = RouteTable.Routes;
            RegisterRoutes(routes);
            var container = new WindsorContainer();
            container.Register(
                Component.For<IBusinessLogic>().LifestyleSingleton().Instance(new BusinessLogic.BusinessLogic()));
            ServiceManager<IBusinessLogic>.Instance.DependencyContainer = container;
        }

        private static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "ArticleNew",
                "Article/New",
                new {controller = "Article", action = "New"}
                );
            routes.MapRoute(
                "Article",
                "Article/{id}",
                new {controller = "Article", action = "Index", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Designer", action = "Index", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Error",
                "{controller}/{action}/{id}",
                new {controller = "Error", action = "NotFound", id = UrlParameter.Optional}
                );
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception ex = Server.GetLastError();
            _logger.Info(ex);
            if (ex is HttpException) {
//                if (((HttpException) ex).GetHttpCode() == 404) {
//                    Response.Redirect("Error/NotFound");
//                } else {
//                    Response.Redirect("Error/InternalError");
//                }
            }
        }
    }
}