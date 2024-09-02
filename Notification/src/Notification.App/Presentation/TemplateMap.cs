using Notification.App.Presentation.Views.Emails.Welcome;
using Notification.App.Presentation.Views.Texts.Welcome;

namespace Notification.App.Presentation;

public class TemplateMap
{
    private static readonly Dictionary<string, Type> _templateMappings = new Dictionary<string, Type>
    {
        { "WelcomeEmail", typeof(WelcomeEmailViewModel) },
        { "WelcomeSms", typeof(WelcomeSmsTextModel) },

        // Add more mappings as needed
    };

    public static Type GetModelType(string templatePath)
    {
        return (_templateMappings.TryGetValue(templatePath, out var viewModelType) ? viewModelType : null) ?? throw new InvalidOperationException();
    }
}