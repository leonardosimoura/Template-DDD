using AppTemplate.Domain.Entities;
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
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork) :base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public User Add(User obj)
        {
            _unitOfWork.AddNotification(new Domain.Notification.Notification() { Data = DateTime.Now, IsError = false, Message = "Adicionando User", WhoSend = "Application Service" });
            return _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            _unitOfWork.AddNotification(new Domain.Notification.Notification() { Data = DateTime.Now, IsError = false, Message = "GetAll User", WhoSend = "Application Service" });
            var ret = _repository.GetAll();
            _unitOfWork.Commit();
            return ret;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _repository.GetByEmailAndPassword( email,  password);
        }

        public User GetById(object id)
        {
            return _repository.GetById(id);
        }

        public void Remove(User obj)
        {
            _repository.Remove(obj);
        }

        public void Update(User obj)
        {
            _repository.Update(obj);
        }
    }
}
