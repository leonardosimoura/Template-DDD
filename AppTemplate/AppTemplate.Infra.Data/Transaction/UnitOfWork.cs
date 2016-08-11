using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Notification;
using AppTemplate.Domain.Transaction.Interface;

namespace AppTemplate.Infra.Data.Transaction
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IDomainNotification _DomainNotification;
        public UnitOfWork(IDomainNotification DomainNotification)
        {
            _DomainNotification = DomainNotification;
            
        }
        private  object Connection
        {
            get;

            set;
        }

        private string ConnectionString
        {
            get;

            set;
        }

        private  object Transaction
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
                    if (Transaction is SqlTransaction)
                    {
                        ((SqlTransaction)Transaction).Commit();
                        Transaction = null;
                    }
                }
            }
        }

        public void Dispose()
        {
            Commit();
            Transaction = null;
            Connection = null;
            _DomainNotification.ClearNotifications();
        }

        public void InitializeConnection(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            if (Connection == null)
            {
                if (this.ConnectionString != "")
                {
                    Connection = new SqlConnection(this.ConnectionString);
                }
            }
        }

        public void InitializeTransaction()
        {
            if (Connection != null)
            {
                if (Transaction == null)
                {
                    var conn = (SqlConnection)Connection;

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        Transaction = conn.BeginTransaction();
                    }
                }
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                ((SqlTransaction)Transaction).Rollback();
            }
        }


        public object GetConnection()
        {
            if (Connection != null)
            {
                if (((SqlConnection)Connection).State == System.Data.ConnectionState.Closed)
                {
                    ((SqlConnection)Connection).Open();
                }
            }

            return (SqlConnection)Connection;
        }

        public object GetSqlCommand(string procedure)
        {
            return new SqlCommand(procedure, (SqlConnection)GetConnection(), (SqlTransaction)GetTransaction());

        }

        public object GetTransaction()
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
            _DomainNotification.ClearNotifications();
        }
    }
}
