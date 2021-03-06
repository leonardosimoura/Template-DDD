﻿using AppTemplate.Domain.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Notification
{
    public class DomainNotification : IDomainNotification
    {
        private List<Notification> _errors;
        public DomainNotification()
        {
            _errors = new List<Notification>();
        }
        public void AddNotification(Notification notification)
        {
            _errors.Add(notification);
        }

        public void AddNotificationRange(IEnumerable<Notification> notifications)
        {
            _errors.AddRange(notifications);
        }

        public void Clear()
        {
            _errors.Clear();
        }

        public IEnumerable<Notification> GetAllErrors()
        {
            return _errors.Where(n => n.IsError == true).OrderBy( o => o.Data).ToList();
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _errors.Where( n => n.IsError == false).OrderBy(o => o.Data).ToList();
        }

        public IEnumerable<Notification> GetAll()
        {
            return _errors.OrderBy(o => o.Data).ToList();
        }

        public bool HasError()
        {
            return 0 != _errors.Count(n => n.IsError == true);
        }

        public bool HasNotification()
        {
            return 0 != _errors.Count(n => n.IsError == false);
        }
    }
}
