using SharedKernel.Main.Domain.Notification.Setups;

namespace SharedKernel.Main.Application.Common.Common.Interfaces;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}