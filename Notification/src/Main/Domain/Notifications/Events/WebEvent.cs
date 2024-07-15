#nullable disable

namespace ACL.Application.Domain.Notifications.Events
{
    public class WebEvent
    {
        public int Id { get; set; }
        public int NotificationEventId { get; set; }
        public int NotificationCredentialId { get; set; }
        public int NotificationReceiverGroupId { get; set; }
        public string Name { get; set; }
        public bool IsAllowFromApp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}