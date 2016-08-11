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
    public class UserTesteService: ServiceBase<User> ,  IUserTesteService
    {
        private readonly IUserTesteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserTesteService(IUserTesteRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
