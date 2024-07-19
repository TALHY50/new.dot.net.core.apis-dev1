using Notification.App.Application.Common;
using Notification.App.Application.Common.Exceptions;

namespace Notification.App.Domain.ValueObjects;

public class NotificationType : ValueObject
{
    static NotificationType()
    {
    }

    private NotificationType()
    {
    }

    private NotificationType(int type)
    {
        Type = type;
    }

    public static NotificationType From(int type)
    {
        var credentialType = new NotificationType { Type = type };

        return !SupportedCredentialTypes.Contains(credentialType) ? throw new UnsupportedNotificationTypeException(type) : credentialType;
    }

    public static NotificationType Mail => new(1);

    public static NotificationType Sms => new(2);

    public static NotificationType Web => new(3);

    public int Type { get; private set; } = 0;

    public static implicit operator int(NotificationType type)
    {
        return (int)type;
    }

    public static explicit operator NotificationType(int type)
    {
        return From(type);
    }

    protected static IEnumerable<NotificationType> SupportedCredentialTypes
    {
        get
        {
            yield return Mail;
            yield return Sms;
            yield return Web;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
    }
}