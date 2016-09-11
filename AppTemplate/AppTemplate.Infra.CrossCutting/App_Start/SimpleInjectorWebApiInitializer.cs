[assembly: WebActivator.PostApplicationStartMethod(typeof(AppTemplate.Infra.CrossCutting.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace AppTemplate.Infra.CrossCutting.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Domain.Interfaces.Repository;
    using Data.Repositories;
    using Domain.Interfaces.Service;
    using AppService.Service;
    using Data.Transaction;
    using Domain.Notification;
    using Domain.Notification.Interfaces;
    using Domain.Transaction.Interface;
    using SimpleInjector.Extensions.ExecutionContextScoping;
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static Container Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle(); 
            //container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            InitializeContainer(container);

            return container;
        }

        private static void InitializeContainer(Container container)
        {

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));

            //For instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IAutenticacaoApiRepository, AutenticacaoApiRepository>(Lifestyle.Transient);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IAutenticacaoApiService, AutenticacaoApiService>(Lifestyle.Transient);

            container.Register<IUnitOfWorkTS, UnitOfWorkTS>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDomainNotification, DomainNotification>(Lifestyle.Scoped);

            //container.RegisterWebApiRequest<IUserRepository, UserRepository>();
            //container.Register<IAutenticacaoApiRepository, AutenticacaoApiRepository>(Lifestyle.Transient);


            //container.RegisterWebApiRequest<IUserService, UserService>();
            //container.Register<IAutenticacaoApiService, AutenticacaoApiService>(Lifestyle.Transient);

            //container.RegisterWebApiRequest<IUnitOfWorkTS, UnitOfWorkTS>();
            //container.RegisterWebApiRequest<IUnitOfWork, UnitOfWork>();
            //container.RegisterWebApiRequest<IDomainNotification, DomainNotification>();
        }
    }
}