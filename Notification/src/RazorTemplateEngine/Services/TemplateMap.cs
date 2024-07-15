namespace Notification.RazorTemplateEngine.Services;

public class TemplateMap
{
    private static readonly Dictionary<string, Type> _templateMappings = new Dictionary<string, Type>
    {
        { "Email.Welcome.cshtml", typeof(WelcomeViewModel) },

        // Add more mappings as needed
    };

    public static Type GetViewModelType(string templatePath)
    {
        return (_templateMappings.TryGetValue(templatePath, out var viewModelType) ? viewModelType : null) ?? throw new InvalidOperationException();
    }
}