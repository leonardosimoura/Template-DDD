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

        dynamic GetConnection();

        dynamic GetTransaction();

        dynamic GetSqlCommand(string procedure, bool initializeTransaction = true);
        
        void Commit();

        void Rollback();

        void Dispose();

    }
}
