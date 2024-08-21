using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Exceptions;

namespace SharedKernel.Main.Domain.ValueObjects;

public class TransportDriverType : ValueObject
{
    static TransportDriverType()
    {
    }

    private TransportDriverType()
    {
    }

    private TransportDriverType(string driver)
    {
        Driver = driver;
    }

    public static TransportDriverType From(string driver)
    {
        var transportDriverType = new TransportDriverType { Driver = driver };

        return !SupportedTransportDriverTypes.Contains(transportDriverType) ? throw new UnsupportedTransportDriverTypeException(driver) : transportDriverType;
    }

    public static TransportDriverType Smtp => new("SMTP");

    public static TransportDriverType Mailgun => new("MAILGUN");

    public static TransportDriverType NotSet => new(string.Empty);

    public string Driver { get; private set; } = "NULL";

    public static implicit operator string(TransportDriverType TransportDriverType)
    {
        return TransportDriverType.ToString();
    }

    public static explicit operator TransportDriverType(string driver)
    {
        return From(driver);
    }

    public override string ToString()
    {
        return Driver;
    }

    protected static IEnumerable<TransportDriverType> SupportedTransportDriverTypes
    {
        get
        {
            yield return Smtp;
            yield return NotSet;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Driver;
    }
}