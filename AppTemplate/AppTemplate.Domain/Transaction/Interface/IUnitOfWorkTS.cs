using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Transaction.Interface
{
    public interface IUnitOfWorkTS : IDomainNotification, IDisposable
    {
        void Begin();

        void Commit();

        
    }
}
