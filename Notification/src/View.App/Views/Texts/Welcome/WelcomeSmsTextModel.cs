#nullable disable
namespace Notification.Renderer.Views.Texts.Welcome;

public class WelcomeSmsTextModel : ISmsTextModel
{
    public string Link { get; set; }

    public string Message(string lang)
    {
        if (lang == "en")
        {
            return Message_En();
        }

        return Message_En();
    }

    public string Message_En()
    {
        var text = $"We're excited to have you get started. Click {this.Link} fun of facts!";

        return text;
    }
}