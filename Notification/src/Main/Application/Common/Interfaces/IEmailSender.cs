namespace Notification.Main.Application.Common.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(List<string> to, string from, string subject, string body);
}