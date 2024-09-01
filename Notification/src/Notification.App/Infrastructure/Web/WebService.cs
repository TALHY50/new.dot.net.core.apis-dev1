using Newtonsoft.Json;

using Notification.App.Application.Interfaces.Services;

using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Models;
using SharedKernel.Main.Infrastructure.Extensions;

namespace Notification.App.Infrastructure.Web;

public class WebService : IWebService
{
    public async Task<Result> SendWebhookAsync(List<string> urls, string content)
    {
        dynamic? json = JsonConvert.DeserializeObject<dynamic>(content);
        var payload = Newtonsoft.Json.JsonConvert.SerializeObject(json);

        if (json is null)
        {
            return Result.Failure(["Json serialization failed"]);
        }

        using var httpClient = new HttpClient();

        // Create HttpContent from JSON
        var httpContent = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");

        try
        {
            List<string> errors = [];
            foreach (var url in urls)
            {
                var response = await httpClient.PostAsync(url, httpContent).ConfigureAwait(false);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    errors.Add($"Failed to send JSON data. Status code: {response.StatusCode}");
                }
            }

            if (! errors.Safe().Any())
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(errors);
            }
        }
        catch (Exception ex)
        {
            return Result.Failure([$"An error occurred: {ex.Message}"]);
        }
    }
}