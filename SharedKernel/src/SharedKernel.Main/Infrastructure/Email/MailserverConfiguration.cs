using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;

namespace SharedKernel.Main.Infrastructure.Email;

public class MailserverConfiguration
{
    public string Hostname { get; set; } = "localhost";
    public int Port { get; set; } = 25;

    public TransportDriverType TransportDriverType { get; set; } = TransportDriverType.NotSet;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool EnableSsl { get; set; } = false;
}