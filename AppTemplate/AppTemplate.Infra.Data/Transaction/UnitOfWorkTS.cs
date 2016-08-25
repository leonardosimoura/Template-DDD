using AppTemplate.Domain.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTemplate.Domain.Notification;
using AppTemplate.Domain.Notification.Interfaces;

namespace AppTemplate.Infra.Data.Transaction
{
    public class UnitOfWorkTS : IUnitOfWorkTS
    {

        private  System.Transactions.TransactionScope scope;
        private readonly IDomainNotification _DomainNotification;

        public UnitOfWorkTS(IDomainNotification DomainNotification)
        {
            _DomainNotification = DomainNotification;
        }        

        public void Dispose()
        {
            scope.Dispose();
            _DomainNotification.Clear();
        }

        public void Begin()
        {
            if (scope == null)
            {
                scope = new System.Transactions.TransactionScope();
            }            
        }

        public void Commit()
        {
            scope.Complete();
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
