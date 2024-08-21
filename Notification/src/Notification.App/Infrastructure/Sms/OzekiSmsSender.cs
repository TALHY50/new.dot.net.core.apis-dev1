using System.Text;
using System.Web;

using SharedKernel.Main.Application.Common.Common.Interfaces;
using SharedKernel.Main.Application.Common.Common.Models;

namespace Notification.App.Infrastructure.Sms;

public class OzekiSmsSender(ILogger<OzekiSmsSender> _logger, SmsProviderConfiguration _provider) : ISmsSender
{
    public async Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body)
    {
        var username = "admin@localhost";
        var password = "123456";
        var messagetype = "SMS:TEXT";
        var httpUrl = "https://localhost:9515/";
        var recipient = HttpUtility.UrlEncode("+36201324567", Encoding.UTF8);
        var messagedata = HttpUtility.UrlEncode("TestMessage", Encoding.UTF8);

        var sendString = $"{httpUrl}api?action=sendmessage&username=" +
                         $"{username}&password={password}" +
                         $"&recipient={recipient}&messagetype=" +
                         $"{messagetype}&messagedata={messagedata}";

        Console.WriteLine("Sending request: " + sendString);

        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            (sender, cert, chain, sslPolicyErrors) => { return true; };

        using var client = new HttpClient(handler);

        try
        {
            var response = await client.GetStringAsync(sendString);
            Console.WriteLine("Http response received: ");
            Console.WriteLine(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        _logger.LogInformation(_provider.Hostname);
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return await Task.FromResult(Result.Success());
    }
}