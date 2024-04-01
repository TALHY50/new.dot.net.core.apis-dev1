using System.Text;
using System.Text.RegularExpressions;

namespace SharedLibrary.Utilities
{
    /// <summary>
    /// string class extension helper
    /// </summary>
    public static class Str
    {

        /// <summary>
        /// String extension Function to truncate a string to a specified length
        /// </summary>
        /// <param name="input">String itself</param>
        /// <param name="maxLength">length</param>
        /// <returns></returns>
        public static string Truncate(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                return input.Substring(0, maxLength);
            }
        }

        /// <summary>
        /// String extension Function to fill a string with a specified character until it reaches a specified length
        /// </summary>
        /// <param name="input">tring itself</param>
        /// <param name="length">int</param>
        /// <param name="fillChar">fill char</param>
        /// <returns></returns>
        public static string Fill(this string input, int length, char fillChar)
        {
            if (string.IsNullOrEmpty(input) || input.Length >= length)
            {
                return input;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(input);
                int fillCount = length - input.Length;

                for (int i = 0; i < fillCount; i++)
                {
                    stringBuilder.Append(fillChar);
                }

                return stringBuilder.ToString();
            }
        }

        public static string ToSnakeCase(string text)
        {
            text = Regex.Replace(text, "(.)([A-Z][a-z]+)", "$1_$2");
            text = Regex.Replace(text, "([a-z0-9])([A-Z])", "$1_$2");
            return text.ToLower();
        }

        public static string PadLeft(string s, int padLen, char padWith)
        {
            return s.PadLeft(padLen, padWith);

        }

        public static string? AsAscii(this string? source)
        {
            if (source != null)
            {
                string asAscii = Encoding.ASCII.GetString(
                Encoding.Convert(
                    Encoding.UTF8,
                    Encoding.GetEncoding(
                        Encoding.ASCII.EncodingName,
                        new EncoderReplacementFallback(string.Empty),
                        new DecoderExceptionFallback()
                    ),
                    Encoding.UTF8.GetBytes(source)
                )
            );

                return asAscii;
            }
            return null;
        }

        public static string[]? ToArr(string input, char delimiter)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
                return input.Split(delimiter, StringSplitOptions.None);
            }
        }


        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }


        public static string FillLeft(this string source, string fillWith)
        {
            if (source.Length == 1)
                return fillWith + source;
            return source;
        }


        public static bool IsNull(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source) || source == "null")
            {
                return true;
            }

            return false;
        }
        
        
        public static string ExtractNumbers(string input)
        {
            // Regular expression to match numbers
            Regex regex = new Regex(@"\d+");

            // Extract matches
            MatchCollection matches = regex.Matches(input);

            // Concatenate matched numbers
            string result = "";
            foreach (Match match in matches)
            {
                result += match.Value;
            }

            return result;
        }
        
        
        public static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        
        public static string ReplaceAll(this string seed, string[] chars, string replacementCharacter)
        {
            return chars.Aggregate(seed, (str, cItem) => str.Replace(cItem, replacementCharacter));
        }





    }
}
