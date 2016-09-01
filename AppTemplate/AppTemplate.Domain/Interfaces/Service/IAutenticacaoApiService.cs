using AppTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Interfaces.Service
{
    public interface IAutenticacaoApiService
    {
        User Authenticate(string user, string password);
    }
}
