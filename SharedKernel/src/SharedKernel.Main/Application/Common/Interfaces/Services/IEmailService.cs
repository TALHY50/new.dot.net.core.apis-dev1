using SharedKernel.Main.Notification.Domain.Entities.Setups;

namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}