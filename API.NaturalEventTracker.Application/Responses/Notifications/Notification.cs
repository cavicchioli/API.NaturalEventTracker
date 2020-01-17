using MediatR;

namespace API.NaturalEventTracker.Application.Notifications
{
    public class Notification : INotification
    {
        public NotificationType Type { get; protected set; }
        public string Value { get; protected set; }

        public Notification(NotificationType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
