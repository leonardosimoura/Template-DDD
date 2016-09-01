using AppTemplate.Domain.Entities;
using AppTemplate.Domain.Interfaces.Repository;
using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Domain.Scopes;
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
        private readonly IUnitOfWorkTS _unitOfWork;
        public UserService(IUserRepository repository, IUnitOfWorkTS unitOfWork) :base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddRange(IEnumerable<User> lista)
        {
            foreach (var item in lista)
            {
                Add(item);
            }
        }

        public User Add(User obj)
        {
            _unitOfWork.AddNotification(new Domain.Notification.Notification("Adicionando User", "Application Service",false));

            //Opcional fazer um if aqui para proseguir
            if (obj.RegisterScopeIsValid(_unitOfWork))
            {
                obj.Register();
            }
            
            var ret = _repository.Add(obj);
            
            return ret;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            _unitOfWork.AddNotification(new Domain.Notification.Notification("GetAll User", "Application Service",false));
            var ret = _repository.GetAll();
            
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
