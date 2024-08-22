namespace SharedKernel.Main.Contracts.Notificaiton;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);