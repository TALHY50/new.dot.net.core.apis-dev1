#nullable disable

namespace Notification.App.Domain.Entities.Events;

public class AppEventData
{
    public int Id { get; set; }

    public int NotificationEventId { get; set; }

    public string ReferenceUniqueId { get; set; }

    public string Data { get; set; }

    public string AttachmentInfo { get; set; }

    public string Receivers { get; set; }

    public string Url { get; set; }

    public string Path { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}



