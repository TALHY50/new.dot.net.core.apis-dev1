#nullable disable
namespace ACL.Application.Domain.Notifications.Outgoings;

public class EmailOutgoing
{
    public int Id { get; set; }
    public int NotificationCredentialId { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public string To { get; set; }
    public string Cc { get; set; }
    public string Bcc { get; set; }
    public bool IsAttachment { get; set; }
    public string AttachmentDetails { get; set; }
    public int Status { get; set; }
    public int Attempt { get; set; }
    public DateTime? SentAt { get; set; }
    public int NotificationEventId { get; set; }
    public string NotificationEventName { get; set; }
    public int CompanyId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}