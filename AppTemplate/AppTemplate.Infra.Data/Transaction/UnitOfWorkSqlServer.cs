using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Notification;
using AppTemplate.Domain.Transaction.Interface;
using System.Data.Common;

namespace AppTemplate.Infra.Data.Transaction
{
    public class UnitOfWorkSqlServer : IDisposable, IUnitOfWork
    {
        private readonly IDomainNotification _DomainNotification;
        public UnitOfWorkSqlServer(IDomainNotification DomainNotification)
        {
            _DomainNotification = DomainNotification;

        }
        private DbConnection Connection
        {
            get;

            set;
        }

        private string ConnectionString
        {
            get;

            set;
        }

        private DbTransaction Transaction
        {
            get;

            set;
        }

        public void Commit()
        {
            if (!_DomainNotification.HasError())
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                    Transaction = null;

                }
            }
        }

        public void Dispose()
        {
            Commit();
            Transaction = null;
            Connection = null;
            _DomainNotification.Clear();
        }

        public void InitializeConnection<TypeConnection>(string ConnectionString) where TypeConnection : DbConnection
        {
            this.ConnectionString = ConnectionString;
            if (Connection == null)
            {
                if (this.ConnectionString != "")
                {
                    Connection = (TypeConnection)Activator.CreateInstance(typeof(TypeConnection), new object[] { this.ConnectionString });
                    //Connection = new SqlConnection(this.ConnectionString);
                }
            }
        }

        public void InitializeTransaction()
        {
            if (Connection != null)
            {
                if (Transaction == null)
                {
                    if (Connection.State == System.Data.ConnectionState.Open)
                    {
                        Transaction = Connection.BeginTransaction();
                    }
                }
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        public DbConnection GetConnection()
        {
            if (Connection != null)
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            return Connection;
        }

        public TypeCommand GetSqlCommand<TypeCommand>(string procedure, bool initializeTransaction = true) where TypeCommand : DbCommand
        {
            if (initializeTransaction == true)
            {
                GetConnection();
                InitializeTransaction();
            }
            
            return (TypeCommand)Activator.CreateInstance(typeof(TypeCommand), new object[] { procedure, GetConnection(), GetTransaction() }); ;
            // return new SqlCommand(procedure, (SqlConnection)GetConnection(), (SqlTransaction)GetTransaction());
        }

        public DbTransaction GetTransaction()
        {
            return Transaction;
        }

        public bool HasError()
        {
            return _DomainNotification.HasError();
        }

        public bool HasNotification()
        {
            return _DomainNotification.HasNotification();
        }

        public void AddNotification(Notification notification)
        {
            _DomainNotification.AddNotification(notification);
        }

        public void AddNotificationRange(IEnumerable<Notification> notifications)
        {
            _DomainNotification.AddNotificationRange(notifications);
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _DomainNotification.GetAllNotifications();
        }

        public IEnumerable<Notification> GetAllErrors()
        {
            return _DomainNotification.GetAllErrors();
        }

        public void ClearNotifications()
        {
            _DomainNotification.Clear();
        }

        public IEnumerable<Notification> GetAll()
        {
            return _DomainNotification.GetAll();
        }

        public void Clear()
        {
            _DomainNotification.Clear();
        }
    }
}
