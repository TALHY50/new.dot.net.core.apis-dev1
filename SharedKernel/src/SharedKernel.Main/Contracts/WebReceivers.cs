namespace SharedKernel.Main.Contracts;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);