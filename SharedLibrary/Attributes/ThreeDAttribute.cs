namespace SharedLibrary.Attributes;

sealed class ThreeDAttribute : Attribute
{
    public string DictionaryKey { get; }

    public ThreeDAttribute(string dictionaryKey)
    {
        DictionaryKey = dictionaryKey;
    }
}
