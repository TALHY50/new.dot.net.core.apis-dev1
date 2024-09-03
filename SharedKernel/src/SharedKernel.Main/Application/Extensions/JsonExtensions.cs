using System.Text.Json;
using static System.Text.Json.JsonSerializer;
namespace SharedKernel.Main.Application.Extensions;

public static class JsonExtensions
{
    public static string Minify(this string json)
        => Serialize(Deserialize<JsonDocument>(json));
    
    public static string Minify(this object json)
        => Serialize(Deserialize<JsonDocument>(json.ToString() ?? string.Empty));
}