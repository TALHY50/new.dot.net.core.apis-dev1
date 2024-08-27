using Notification.App.Domain.Entities.Setups;

namespace Notification.App.Application.Interfaces.Services;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}