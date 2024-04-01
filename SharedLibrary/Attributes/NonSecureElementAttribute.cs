namespace SharedLibrary.Attributes
{
    public class NonSecureElementAttribute : Attribute
    {
        public string Key { get; }
        public NonSecureElementAttribute(string key)
        {
            Key = key;
        }
    }
}
