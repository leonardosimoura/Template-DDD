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
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotification _domainNotification;
        private readonly IUnitOfWorkTS _unitOfWorkTS;

        //public RepositoryBase(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public RepositoryBase(IUnitOfWorkTS unitOfWorkTS)
        {

            _unitOfWorkTS = unitOfWorkTS;
        }

        private string[] _Conexoes =
        {
               //@"Server=DESKTOP-8SJ2DID\SQL2016; Initial Catalog=EstudoDDD;  Persist Security Info=true; User ID=EstudoDDD; Password=789632145@"
              @"Server=PC-016\SQL2014_2; Initial Catalog=EstudoDDD;  Persist Security Info=true; User ID=EstudoDDD; Password=789632145@"
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
            //if (_unitOfWork != null)
            //{
            //    _unitOfWork.Dispose();
            //}

            if (_unitOfWorkTS != null)
            {
                _unitOfWorkTS.Dispose();
            }
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

