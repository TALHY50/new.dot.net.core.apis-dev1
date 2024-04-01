namespace SharedLibrary.Attributes;

public class FormElementAttribute : Attribute {
    public string Key { get; }
    public FormElementAttribute(string key) {
        Key = key;
    }
}