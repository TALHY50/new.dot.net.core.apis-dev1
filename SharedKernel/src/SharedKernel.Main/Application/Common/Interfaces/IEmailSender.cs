using SharedKernel.Main.Application.Common.Models;

namespace SharedKernel.Main.Application.Common.Interfaces;

public interface IEmailSender
{
    Task<Result> SendEmailAsync(List<string> to, string from, string subject, string body);
}