using AppTemplate.Domain.Interfaces.Repository;
using AppTemplate.Domain.Notification.Interfaces;
using AppTemplate.Domain.Transaction.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotification _domainNotification;
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string[] _Conexoes =
        {
               //@"Server=54.232.203.19; Initial Catalog=EstudoDDD;  Persist Security Info=true; User ID=EstudoDDD; Password=789632145@"
               @"Server=54.232.203.19; Initial Catalog=EstudoDDD;  Persist Security Info=true; User ID=LeonardoMoura; Password=Glicemic070073"
        };

        public enum Connection
        {
            Padrao = 0,
        }

        public  string GetConnectionString(Connection cs = Connection.Padrao)
        {
            return _Conexoes[(int)cs];
        }


        public virtual T Add(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}

