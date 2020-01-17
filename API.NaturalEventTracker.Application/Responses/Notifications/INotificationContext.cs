using System.Collections.Generic;

namespace API.NaturalEventTracker.Application.Notifications
{
    public interface INotificationContext
    {
        bool HasErrorNotifications { get; }
        void NotifyError(string message);
        void NotifySuccess(string message);
        IEnumerable<Notification> GetErrorNotifications();
    }
}
