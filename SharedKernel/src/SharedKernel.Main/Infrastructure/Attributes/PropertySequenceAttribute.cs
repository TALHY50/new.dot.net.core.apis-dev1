namespace SharedKernel.Main.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class PropertySequenceAttribute(int order) : Attribute
{
    public int Order { get; } = order;
}