using Notification.App.Application.Common.Models;

namespace Notification.App.Application.Common.Interfaces;

public interface IEmailSender
{
    Task<Result> SendEmailAsync(List<string> to, string from, string subject, string body);
}