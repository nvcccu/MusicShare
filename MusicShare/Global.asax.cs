using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils.Log;
using CommonUtils.ServiceManager;
using SquishIt.Framework;

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
            Application_Bundle();
        }
        protected void Application_Bundle() {
            //SquishIt
            Bundle.Css()
                .Add("~/Content/Libraries/Bootstrap/css/bootstrap.min.css")
                .Add("~/Content/Libraries/Bootstrap/css/bootstrap-theme.min.css")
                .Add("~/Content/Libraries/MarkItUp/css/base.css")
                .Add("~/Content/Libraries/MarkItUp/css/style.css")
                .Add("~/Content/Font/FontAwesome/font-awesome.min.css")
                .Add("~/Content/Less/Layout.min.css")
                .Add("~/Content/Less/Global.min.css")
                .Add("~/Content/Less/Designer/Navigation.css")
                .Add("~/Content/Less/Designer/Designer.css")
                .Add("~/Content/Less/Ask/Ask.css")
                .Add("~/Content/Less/Ask/List.css")
                .Add("~/Content/Less/Article/ArticlePreview.css")
                .Add("~/Content/Less/Lesson/Plan.css")
                .Add("~/Content/Less/Lesson/Lesson.css")
                .Add("~/Content/Less/Lesson/Index.css")
                .Add("~/Content/Less/Lesson/Navigation.css")
                .Add("~/Content/Less/Lesson/Stat.css")
                .Add("~/Content/Less/Lesson/Promo.css")
                .Add("~/Content/Less/Auth/AuthPopup.css")
                .Add("~/Content/Less/DerzkieSchi/AdminLesson.css")
                .AsCached("main", "~/assets/css/main");
            Bundle.JavaScript()
                .Add("/Content/Script/jquery-1.10.2.min.js")
                .Add("/Content/Script/jquery.form.js")
                .Add("/Content/Libraries/Jquery/jquery-ui.min.js")
                .Add("/Content/Script/knockout-3.3.0.min.js")
                .Add("/Content/Script/knockout-sortable.js")
                .Add("/Content/Libraries/Showdown/Showdown.js")
                .Add("/Content/Libraries/Bootstrap/js/bootstrap.min.js")
                .Add("/Content/Libraries/MarkItUp/js/jquery.markitup.js")
                .Add("/Content/Libraries/MarkItUp/js/set.js")

                .Add("/Content/Script/CommonScripts/Log.js")
                .Add("/Content/Script/CommonScripts/MusicShare.js")
                .Add("/Content/Script/Designer/designer.js")
                .Add("/Content/Script/DerzkieSchi/newProductAdmin.js")
                .Add("/Content/Script/DerzkieSchi/changeProductAdmin.js")
                .Add("/Content/Script/DerzkieSchi/selectProductAdmin.js")
                .Add("/Content/Script/Designer/MenuAnimateHelper.js")
                .AsCached("main", "~/assets/js/main");
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
                "SaveLessonStat",
                "Lesson/SaveExercisesSpeed",
                new {controller = "Lesson", action = "SaveExercisesSpeed", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "MinimizedLesson",
                "MinLesson/{id}",
                new {controller = "Lesson", action = "MinimizedLesson"}
                );
            routes.MapRoute(
                "SavePlan",
                "Lesson/SavePlan",
                new {controller = "Lesson", action = "SavePlan", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "AddExrciseToPlan",
                "Lesson/AddExrciseToPlan",
                new {controller = "Lesson", action = "AddExrciseToPlan"}
                );
            routes.MapRoute(
                "DeleteStatPreset",
                "Lesson/DeleteStatPreset",
                new {controller = "Lesson", action = "DeleteStatPreset"}
                );
            routes.MapRoute(
                "SaveStatPreset",
                "Lesson/SaveStatPreset",
                new {controller = "Lesson", action = "SaveStatPreset"}
                );
            routes.MapRoute(
                "UpdateStatPreset",
                "Lesson/UpdateStatPreset",
                new {controller = "Lesson", action = "UpdateStatPreset"}
                );
            routes.MapRoute(
                "UpdatePlan",
                "Lesson/UpdatePlan",
                new {controller = "Lesson", action = "UpdatePlan", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "SaveHomework",
                "Lesson/SaveHomework",
                new {controller = "Lesson", action = "SaveHomework"}
                );
            routes.MapRoute(
                "Boomstarter",
                "Boomstarter",
                new {controller = "Lesson", action = "Boomstarter"}
                );
            routes.MapRoute(
                "Plan",
                "Plan/{id}",
                new {controller = "Lesson", action = "Plan", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Plans",
                "Plans/",
                new {controller = "Lesson", action = "Plans", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Train",
                "Train/{planId}",
                new {controller = "Lesson", action = "Train", planId = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Promo",
                "Promo/",
                new {controller = "Lesson", action = "Promo"}
                );
            routes.MapRoute(
                "Stat",
                "Stat/",
                new {controller = "Lesson", action = "Stat", planId = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Lesson",
                "Lesson/{id}",
                new {controller = "Lesson", action = "Lesson", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Lesson", action = "Index", id = UrlParameter.Optional}
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