#nullable disable
namespace SharedKernel.Main.Domain.Notifications.Outgoings
{
    public class WebOutgoing
    {
        public int Id { get; set; }
        public int NotificationCredentialId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Host { get; set; }
        public int Status { get; set; }
        public int Attempt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CompanyId { get; set; }
        public int NotificationEventId { get; set; }
        public string NotificationEventName { get; set; }
    }
}