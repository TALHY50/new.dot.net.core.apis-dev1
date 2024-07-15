using Notification.Application.Domain.Setups;

namespace Notification.Main.Application.Common.Interfaces;

public interface IEmailService
{
    public Task<string> GenerateEmailBody(string templatePath, string jsonData);

    public Task<IEmailSender?> GetEmailSender(Credential credential);
}