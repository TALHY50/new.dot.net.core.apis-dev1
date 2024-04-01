using System.Collections;
using System.Text;
using Craftgate.Request.Dto;

namespace SharedLibrary.Utilities
{
    public class Hider
    {
        public const int BIN_DIGITS_LEN = 8;
        public const int LAST_DIGITS_LEN = 4;
        
        public static string HideValues(dynamic data, List<string> hides, Dictionary<string, string>? masks = null, string replaceWith = "***", bool shouldMask = true)
        {
            // To statically log all requests
            if (shouldMask)
            {
                masks ??= new Dictionary<string, string>();
                foreach (string hide in hides)
                {
                    if (hide.Length >= (BIN_DIGITS_LEN + LAST_DIGITS_LEN))
                    {
                        string key = "masked_" + Convert.ToBase64String(Encoding.UTF8.GetBytes(hide));
                        masks.Add(key, hide);
                    }
                }
            }

            if (masks != null && masks.Count > 0)
            {
                return MaskAndHide(data, hides, masks);
            }

            try
            {
                if (data is string)
                {
                    foreach(string hide in hides) data = data.ReplaceAll(hide, replaceWith);
                    
                }
                else if (data is IEnumerable enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        if (item is string itemString)
                        {
                            itemString = HideValues(itemString, hides, masks, replaceWith, shouldMask);
                        }
                    }
                }

                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }


        private static string MaskAndHide(string data, List<string>? hides, Dictionary<string, string> masks)
        {
            try
            {
                var maskedArr = new Dictionary<string, string>();
                foreach (var kvp in masks.OrderByDescending(kvp => kvp.Value.Length))
                {
                    string k = kvp.Key;
                    string v = kvp.Value;
                    if (v.Length < 15)
                    {
                        int len = v.Length;
                        int firstLength, lastLength;
                        if (len < BIN_DIGITS_LEN)
                        {
                            firstLength = len;
                            lastLength = 0;
                        }
                        else
                        {
                            firstLength = (int)Math.Round((BIN_DIGITS_LEN / 15.0) * len);
                            lastLength = (int)Math.Round((LAST_DIGITS_LEN / 15.0) * len);
                        }
                        string masked = Mask(v, firstLength, lastLength);
                        maskedArr.Add(k ,masked);
                        data = HideValues(data, new List<string>{ v }, new Dictionary<string, string>(), k, false);
                    }
                    else
                    {
                        string masked = Mask(v);
                        maskedArr.Add(k, masked);
                        data = HideValues(data, new List<string> { v }, new Dictionary<string, string>(), "***", false);
                    }
                }

                data = HideValues(data, hides!, new Dictionary<string, string>(), "***", false);

                foreach (var kvp in maskedArr)
                {
                    string k = kvp.Key;
                    string v = kvp.Value;
                    data = HideValues(data, new List<string> { k }, new Dictionary<string, string>(), v, false);
                }

                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }

        public static string Mask(string str, int firstLength = BIN_DIGITS_LEN, int lastLength = LAST_DIGITS_LEN)
        {
            string first = str.Substring(0, firstLength);
            string last = str.Substring(str.Length - lastLength);
            return first + "***" + last;
        }
    }
}
