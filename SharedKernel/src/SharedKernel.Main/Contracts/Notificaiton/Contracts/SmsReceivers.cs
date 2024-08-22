namespace SharedKernel.Main.Contracts.Notificaiton.Contracts;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);