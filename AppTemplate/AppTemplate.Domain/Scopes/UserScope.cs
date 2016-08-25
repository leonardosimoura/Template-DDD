using AppTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Scopes
{
    public static class UserScope
    {

        // Todo: Melhorar para retornar apenas um bool e conseguir inserir as Notifications
        public static IEnumerable<Notification.Notification> RegisterScopeIsValid(this User user)
        {
            var lista = new List<Notification.Notification>();

            if (user.Email == "" || user.Email.Contains("@") == false)
            {
                lista.Add(new Notification.Notification("Insira um Email válido" ,"RegisterScope" ,true));
            }

            return lista;
        }
    }
}
