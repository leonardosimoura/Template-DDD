[assembly: WebActivator.PostApplicationStartMethod(typeof(AppTemplate.Service.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace AppTemplate.Service.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static Container Initialize()
        {
            var container = AppTemplate.Infra.CrossCutting.App_Start.SimpleInjectorWebApiInitializer.Initialize();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            

            container.Verify();

            

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}