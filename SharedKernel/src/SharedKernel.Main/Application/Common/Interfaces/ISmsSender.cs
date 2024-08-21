using SharedKernel.Main.Application.Common.Models;

namespace SharedKernel.Main.Application.Common.Interfaces;

public interface ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body);
}