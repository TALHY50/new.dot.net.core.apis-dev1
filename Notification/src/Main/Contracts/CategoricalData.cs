namespace Notification.Application.Contracts;

public record CategoricalData(
    string Category,
    string Name,
    string Data = "");