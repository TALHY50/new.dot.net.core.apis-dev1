#nullable disable
using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;

namespace SharedKernel.Main.Notification.Domain.Entities.Setups;

public class Credential
{
    public int Id { get; set; }

    public NotificationType Type { get; set; }

    public string Title { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string ApiKey { get; set; }

    public string EncryptionType { get; set; }

    public TransportDriverType TransportDriver { get; set; }

    public string FromAddress { get; set; }

    public string FromName { get; set; }

    public int CompanyId { get; set; }

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}