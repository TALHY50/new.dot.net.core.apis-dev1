namespace Notification.App.Contracts;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);