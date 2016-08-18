using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Transaction.Interface
{
    public interface IUnitOfWork : IDomainNotification
    {
        void InitializeConnection<TypeConnection>(string ConnectionString) where TypeConnection : DbConnection;

        void InitializeTransaction();

        DbConnection GetConnection();

        DbTransaction GetTransaction();

        TypeCommand GetSqlCommand<TypeCommand>(string procedure, bool initializeTransaction = true) where TypeCommand : DbCommand;
        
        void Commit();

        void Rollback();

        void Dispose();

    }
}
