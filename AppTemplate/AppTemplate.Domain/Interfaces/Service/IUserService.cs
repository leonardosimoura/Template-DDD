using AppTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Interfaces.Service
{
    public interface IUserService : IServiceBase<User>
    {
        User GetByEmailAndPassword(string email, string password);

        void AddRange(IEnumerable<User> lista);
    }
}
