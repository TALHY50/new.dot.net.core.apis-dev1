namespace SharedKernel.Main.Infrastructure.Attributes;

public class FormElementAttribute : Attribute {
    public string Key { get; }
    public FormElementAttribute(string key) {
        Key = key;
    }
}