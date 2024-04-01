namespace SharedLibrary.Attributes;

sealed class TwoDAttribute : Attribute
{
    public string DictionaryKey { get; }

    public TwoDAttribute(string dictionaryKey)
    {
        DictionaryKey = dictionaryKey;
    }
}
