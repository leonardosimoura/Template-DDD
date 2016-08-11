using AppTemplate.Domain.Interfaces.Repository;
using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Domain.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.AppService.Service
{
    public class ServiceBase<T> : IDisposable,IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repostory;
        private readonly IUnitOfWork _unitOfWork;
        public ServiceBase(IRepositoryBase<T> repostory, IUnitOfWork unitOfWork)
        {
            _repostory = repostory;
            _unitOfWork = unitOfWork;
        }
        public T Add(T obj)
        {
            return _repostory.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _repostory.GetAll();
        }

        public T GetById(object id)
        {
            return _repostory.GetById(id);
        }

        public void Remove(T obj)
        {
            _repostory.Remove(obj);
        }

        public void Update(T obj)
        {
            _repostory.Update(obj);
        }

        public void Dispose()
        {
            _repostory.Dispose();
            _unitOfWork.Dispose();
        }
        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
