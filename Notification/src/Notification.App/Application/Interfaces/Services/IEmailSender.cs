using SharedKernel.Main.Application.Common.Models;

namespace Notification.App.Application.Interfaces.Services;

public interface IEmailSender
{
    Task<Result> SendEmailAsync(List<string> to, string from, string subject, string body);
}