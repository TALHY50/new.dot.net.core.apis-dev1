namespace SharedKernel.Main.Application.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Converts the string to an unsigned integer (uint).
    /// </summary>
    /// <param name="input">The string input to convert.</param>
    /// <param name="defaultValue">The default value to return if the conversion fails.</param>
    /// <returns>The converted uint value or the default value if conversion fails.</returns>
    public static uint ToUIntOrDefault(this string input, uint defaultValue = 0)
    { 
        if (uint.TryParse(input, out uint result))
        {
            return result;
        }
        return defaultValue;
    }
}