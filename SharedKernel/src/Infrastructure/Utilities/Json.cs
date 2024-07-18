using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharedKernel.Infrastructure.Utilities;

public static class Json
{
    public static string Serialize<T>(T value, JsonSerializerSettings? settings = null)
    {
        return JsonConvert.SerializeObject(value, settings);
    }

    public static T? Derialize<T>(string value, JsonSerializerOptions? options = null)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }
    
    public static bool IsValidJson(this string jsonString)
    {
        try
        {
            JToken.Parse(jsonString);
            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }

}