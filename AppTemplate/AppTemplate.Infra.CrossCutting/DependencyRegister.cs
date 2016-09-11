using AppTemplate.AppService.Service;
using AppTemplate.Domain.Interfaces.Repository;
using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Domain.Notification;
using AppTemplate.Domain.Notification.Interfaces;
using AppTemplate.Domain.Transaction.Interface;
using AppTemplate.Infra.Data.Repositories;
using AppTemplate.Infra.Data.Transaction;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Infra.CrossCutting
{
    public static class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {

            container.RegisterType< IDomainNotification,DomainNotification > (new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());


            container.RegisterType(typeof(IServiceBase<>), typeof(ServiceBase<>), new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAutenticacaoApiService, AutenticacaoApiService>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>),new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAutenticacaoApiRepository, AutenticacaoApiRepository>(new HierarchicalLifetimeManager());
        }
    }
}

