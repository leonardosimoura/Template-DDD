using AppTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByEmailAndPassword(string email , string password);
    }
}
