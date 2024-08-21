using SharedKernel.Main.Application.Common.Models;

namespace SharedKernel.Main.Application.Common.Interfaces;

public interface IWebService
{
    public Task<Result> SendWebhookAsync(List<string> urls, string content);
}