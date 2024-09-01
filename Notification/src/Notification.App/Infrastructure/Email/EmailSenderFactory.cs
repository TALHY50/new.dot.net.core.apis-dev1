using Microsoft.Extensions.Logging;

using Notification.App.Application.Interfaces.Services;
using Notification.App.Domain.Entities.ValueObjects;

namespace Notification.App.Infrastructure.Email;

public class EmailSenderFactory
{
    public static IEmailSender? FromConfiguration(MailserverConfiguration mailserverConfiguration)
    {
        var logger = new LoggerFactory();
        var driverType = mailserverConfiguration.TransportDriverType;
        if (driverType.Driver == TransportDriverType.Smtp.Driver)
        {
            return new SmtpEmailSender(logger.CreateLogger<SmtpEmailSender>(), mailserverConfiguration);
        }

        if (driverType == TransportDriverType.NotSet)
        {
            return new FakeEmailSender(logger.CreateLogger<FakeEmailSender>());
        }

        return null;
    }
}