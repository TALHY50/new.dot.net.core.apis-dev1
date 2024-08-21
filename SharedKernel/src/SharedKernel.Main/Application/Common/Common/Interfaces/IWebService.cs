using SharedKernel.Main.Application.Common.Common.Models;

namespace SharedKernel.Main.Application.Common.Common.Interfaces;

public interface IWebService
{
    public Task<Result> SendWebhookAsync(List<string> urls, string content);
}