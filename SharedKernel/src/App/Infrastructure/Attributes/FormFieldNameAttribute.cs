namespace App.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class FormFieldNameAttribute : Attribute
{
    public string FieldName { get; }

    public FormFieldNameAttribute(string fieldName)
    {
        FieldName = fieldName;
    }
}