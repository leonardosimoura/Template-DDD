using AppTemplate.Domain.Entities;
using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Scope
{
    public static class UserScope
    {

        //// Todo: Melhorar para retornar apenas um bool e conseguir inserir as Notifications
        //public static IEnumerable<Notification.Notification> RegisterScopeIsValid(this User user)
        //{
        //    var lista = new List<Notification.Notification>();

        //    if (user.Email == "" || user.Email.Contains("@") == false)
        //    {
        //        lista.Add(new Notification.Notification("Insira um Email válido" , "UserRegisterScope", true));
        //    }

        //    return lista;
        //}

        public static bool RegisterScopeIsValid(this User user, IDomainNotification domainNotification)
        {
            var lista = new List<Notification.Notification>();

            if (user.Email == "" || user.Email.Contains("@") == false)
            {
                lista.Add(new Notification.Notification("Insira um Email válido", "UserRegisterScope", true));
            }

            if (user.RegisterDate.HasValue || user.Id != 0)
            {
                lista.Add(new Notification.Notification("Usuário ja registrado", "UserRegisterScope", true));
            }

            domainNotification.AddNotificationRange(lista);

            return lista.Count == 0;
        }
    }
}
