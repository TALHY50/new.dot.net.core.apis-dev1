using Newtonsoft.Json;

namespace App.Infrastructure.Services;

#pragma warning disable CS8600 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8765 // Possible null reference argument.
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
