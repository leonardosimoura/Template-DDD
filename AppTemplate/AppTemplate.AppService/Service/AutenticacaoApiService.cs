using AppTemplate.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Entities;
using AppTemplate.Domain.Interfaces.Repository;

namespace AppTemplate.AppService.Service
{
    public class AutenticacaoApiService : IAutenticacaoApiService
    {
        private readonly IAutenticacaoApiRepository _repository;

        public AutenticacaoApiService(IAutenticacaoApiRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(string user, string password)
        {
            return _repository.Authenticate(user, password);
        }
    }
}
