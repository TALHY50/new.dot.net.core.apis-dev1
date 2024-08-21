namespace SharedKernel.Main.Contracts;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);