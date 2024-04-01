namespace SharedLibrary.Services;

using Newtonsoft.Json;

public class JsonPropertyCryptographicTransformer : JsonConverter<string>
{
    public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        string encryptedValue = (string)reader.Value;
        string decryptedValue = Decrypt(encryptedValue);
        return decryptedValue;
    }

    public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
    {
        string encryptedValue = Encrypt(value);
        writer.WriteValue(encryptedValue);
    }

    private string Encrypt(string value)
    {
        return Cryptographer.AppEncrypt(value);
    }

    private string Decrypt(string value)
    {
        return Cryptographer.AppDecrypt(value);
    }
}
