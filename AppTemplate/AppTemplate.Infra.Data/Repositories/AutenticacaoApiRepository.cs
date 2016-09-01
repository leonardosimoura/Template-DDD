using AppTemplate.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Entities;

namespace AppTemplate.Infra.Data.Repositories
{
    public class AutenticacaoApiRepository : IAutenticacaoApiRepository
    {
        public User Authenticate(string user, string password)
        {
            return new User(user, user, password);
        }
    }
}
