using ACL.Application.Domain.Setups;

namespace Notification.Main.Application.Common.Interfaces;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}