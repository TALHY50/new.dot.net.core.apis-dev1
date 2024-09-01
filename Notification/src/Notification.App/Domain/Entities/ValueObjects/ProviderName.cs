using SharedKernel.Main.Application.Exceptions;
using SharedKernel.Main.Domain;

namespace Notification.App.Domain.Entities.ValueObjects;

public class ProviderName : ValueObject
{
    static ProviderName()
    {
    }

    private ProviderName()
    {
    }

    private ProviderName(string name)
    {
        Name = name;
    }

    public static ProviderName From(string name)
    {
        var providerName = new ProviderName { Name = name };

        return !SupportedProviderNames.Contains(providerName) ? throw new UnsupportedProviderNameException(name) : providerName;
    }

    public static ProviderName Ozeki => new("Ozeki");
    public static ProviderName NotSet => new(string.Empty);

    public string Name { get; private set; } = "NotSet";

    public static implicit operator string(ProviderName ProviderName)
    {
        return ProviderName.ToString();
    }

    public static explicit operator ProviderName(string driver)
    {
        return From(driver);
    }

    public override string ToString()
    {
        return Name;
    }

    protected static IEnumerable<ProviderName> SupportedProviderNames
    {
        get
        {
            yield return Ozeki;
            yield return NotSet;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}