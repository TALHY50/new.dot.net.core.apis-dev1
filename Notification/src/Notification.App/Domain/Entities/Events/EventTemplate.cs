#nullable disable
using Notification.App.Domain.Entities.ValueObjects;

namespace Notification.App.Domain.Entities.Events
{
    public class EventTemplate
    {
        public int Id { get; set; }
        public int NotificationEventId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Path { get; set; }
        public NotificationType Type { get; set; }
        public string Variables { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public int Status { get; set; }
        public string Language { get; set; }
        public int CompanyId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}