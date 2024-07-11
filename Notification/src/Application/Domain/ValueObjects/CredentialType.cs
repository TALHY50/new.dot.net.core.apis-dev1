using Notification.Application.Common;
using Notification.Application.Common.Exceptions;

namespace Notification.Application.Domain.ValueObjects;

public class CredentialType : ValueObject
{
    static CredentialType()
    {
    }

    private CredentialType()
    {
    }

    private CredentialType(int type)
    {
        Type = type;
    }

    public static CredentialType From(int type)
    {
        var credentialType = new CredentialType { Type = type };

        return !SupportedCredentialTypes.Contains(credentialType) ? throw new UnsupportedCredentialTypeException(type) : credentialType;
    }

    public static CredentialType Mail => new(1);

    public static CredentialType Sms => new(2);

    public static CredentialType Web => new(3);

    public int Type { get; private set; } = 0;

    public static implicit operator int(CredentialType type)
    {
        return (int)type;
    }

    public static explicit operator CredentialType(int type)
    {
        return From(type);
    }

    protected static IEnumerable<CredentialType> SupportedCredentialTypes
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