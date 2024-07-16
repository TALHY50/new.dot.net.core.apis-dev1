using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Domain.ValueObjects;
using Notification.Main.Infrastructure.Sms;

using Credential = ACL.Application.Domain.Setups.Credential;

namespace Notification.Main.Infrastructure.Services;

public class SmsService : ISmsService
{
    public SmsService()
    {
    }

    public Task<ISmsSender?> GetSmsSender(Credential credential)
    {
        var mailServerConfiguration = GetMailServerConfiguration(credential);
        ISmsSender? emailSender = SmsSenderFactory.FromConfiguration(mailServerConfiguration);
        return Task.FromResult(emailSender);
    }

    private SmsProviderConfiguration GetMailServerConfiguration(ACL.Application.Domain.Setups.Credential credential)
    {
        var config = new SmsProviderConfiguration();
        config.Name = ProviderName.From(credential.Title);
        config.Hostname = credential.Host;
        config.Port = credential.Port;
        config.UserName = credential.Username;
        config.Password = credential.Password;

        return config;
    }
}