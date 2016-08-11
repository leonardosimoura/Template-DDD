using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Notification.Interfaces
{
    public interface IDomainNotification
    {
        bool HasError();

        bool HasNotification();

        void AddNotification(Notification notification);

        IEnumerable<Notification> GetAllNotifications();

        IEnumerable<Notification> GetAllErrors();

        void ClearNotifications();
    }
}
