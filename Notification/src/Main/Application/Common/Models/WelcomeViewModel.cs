#nullable disable
namespace Notification.Main.Application.Common.Models;

public class WelcomeViewModel
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string RecipientName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmationLink { get; set; }

    public string WelcomeUrl { get; set; } = string.Empty;
}
