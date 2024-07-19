namespace SharedKernel.Main.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class PropertyOrderAttribute : Attribute
{
    public int Order { get; }

    public PropertyOrderAttribute(int order)
    {
        Order = order;
    }
}