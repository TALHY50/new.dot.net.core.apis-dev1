namespace Notification.Application.Contracts;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);