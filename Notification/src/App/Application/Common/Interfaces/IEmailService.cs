using ACL.Application.Domain.Setups;

namespace Notification.App.Application.Common.Interfaces;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}