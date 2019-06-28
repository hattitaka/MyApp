using MyApp.Areas.Admin.Extentions;
using MyApp.Areas.Admin.Manager;
using MyApp.Areas.Admin.Models.Contexts;
using MyApp.Areas.Admin.Models.Ninject;
using MyApp.Areas.Admin.Models.Repository;
using Ninject;
using System.Configuration;
using System.Data.Entity;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ValueProviderFactories.Factories.Add(new HttpCookieValueProviderFactory());
            // Database.SetInitializer<BasicContext>(new BasicInitializer());

            IKernel kernel = new StandardKernel();
            var productionMode = ConfigurationManager.AppSettings["Production"];
            switch (productionMode)
            {
                case "Debug":
                    kernel.Bind<IUserRepository>().To<InMemoryUserRepository>();
                    kernel.Bind<IContentRepository>().To<InMemoryContentRepository>();
                    break;
                case "Release":
                    kernel.Bind<IUserRepository>().To<UserRepository>();
                    kernel.Bind<IContentRepository>().To<ContentRepository>();
                    break;

            }
            DependencyResolver.SetResolver(new NinjectResolver(kernel));
        }
    }
}
