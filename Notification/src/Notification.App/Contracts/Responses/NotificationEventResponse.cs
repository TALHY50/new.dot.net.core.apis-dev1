namespace Notification.App.Contracts.Responses;

public record NotificationEventResponse(
    int id,
    string category,
    string name,
    bool is_email,
    bool is_sms,
    bool is_web,
    bool is_allow_from_app,
    int created_by_id,
    int updated_by_id,
    int status,
    DateTime created_at,
    DateTime updated_at
    );