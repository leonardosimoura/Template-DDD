using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Transaction.Interface
{
    public interface IUnitOfWork : IDomainNotification
    {
        void InitializeConnection(string ConnectionString);

        void InitializeTransaction();

        object GetConnection();

        object GetTransaction();

        object GetSqlCommand(string procedure);
        
        void Commit();

        void Rollback();

        void Dispose();

    }
}
