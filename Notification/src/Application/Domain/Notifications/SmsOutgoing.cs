#nullable disable
namespace Notification.Application.Domain.Notifications
{
    public class SmsOutgoing
    {
        public int Id { get; set; }
        public int NotificationCredentialId { get; set; }
        public string Content { get; set; }
        public string To { get; set; }
        public int Status { get; set; }
        public int Attempt { get; set; }
        public DateTime? SentAt { get; set; }
        public int NotificationEventId { get; set; }
        public string NotificationEventName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CompanyId { get; set; }
    }
}