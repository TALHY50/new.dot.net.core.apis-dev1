namespace SharedLibrary.Attributes;

public class IgnorableAttribute : Attribute {
    public string Key { get; }
    public IgnorableAttribute(string key) {
        Key = key;
    }
}