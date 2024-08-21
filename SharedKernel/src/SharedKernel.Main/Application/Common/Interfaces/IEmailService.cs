using SharedKernel.Main.Domain.Setups;

namespace SharedKernel.Main.Application.Common.Interfaces;

public interface IEmailService
{
    public Task<IEmailSender?> GetEmailSender(Credential credential);
}