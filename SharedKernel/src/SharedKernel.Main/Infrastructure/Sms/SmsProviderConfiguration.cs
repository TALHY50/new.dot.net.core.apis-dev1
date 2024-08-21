using SharedKernel.Main.Domain.ValueObjects;

namespace SharedKernel.Main.Infrastructure.Sms;

public class SmsProviderConfiguration
{
    public ProviderName Name { get; set; } = ProviderName.NotSet;
    public string Hostname { get; set; } = "localhost";

    public int Port { get; set; } = 25;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}