using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Attributes;
using SharedLibrary.Services;

namespace SharedLibrary.Utilities;

public static class Converter
{
    public static List<T> GetList<T>(Dictionary<int, Dictionary<string, object>> dict)
    {
        var list = new List<T>();

        foreach (var kv in dict)
        {
            T t;
            t = GetObject<T>(kv.Value);
            list.Add(t);
        }
        
        return list;
    }
    
    
    /*
    public static T GetObject<T>(Dictionary<string,object> dict)
    {
        Type type = typeof(T);
        var t = type.GetType();
        var obj = Activator.CreateInstance(type);

        foreach (var kv in dict)
        {
            type.GetProperty(kv.Key).SetValue(obj,kv.Value);
        }
        return (T)obj;
    }*/
    
    public static Dictionary<string, object> ToDictionary<T>(T entity)
    {
        var dictionary = new Dictionary<string, object>();
        var type = typeof(T);
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            var jsonIgnoreAttribute = property.GetCustomAttribute<JsonIgnoreAttribute>();
            if (jsonIgnoreAttribute != null)
            {
                continue; // Skip properties with JsonIgnore attribute
            }
            var jsonAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            var key = jsonAttribute != null ? jsonAttribute.PropertyName : property.Name;
            var value = property.GetValue(entity);

            if (value != null) ;
            {
                dictionary[key] = value;
            }
        }

        return dictionary;
        
    }
    
    public static Dictionary<string, string> ToStringDictionary<T>(T entity)
    {
        var dictionary = ToDictionary(entity);
        
        Dictionary<string, string> stringDictionary = dictionary
            .ToDictionary(kv => kv.Key, kv => kv.Value.ToString());
        
        return stringDictionary;
        
    }



    public static FormUrlEncodedContent ToFormUrlEncodedContent(Dictionary<string, string> queryParams)
    {
        
        return new FormUrlEncodedContent(queryParams);
        
    }
    
    public static byte[] Byte(string data)
    {
        return Encoding.ASCII.GetBytes(data);
    }


    
    
    
    
    public static Object GetObject(Dictionary<string, object> dict, Type type)
    {
        var obj = Activator.CreateInstance(type);

        foreach (var kv in dict)
        {
            var prop = type.GetProperty(kv.Key);
            if(prop == null) continue;

            object value = kv.Value;
            if (value is Dictionary<string, object>)
            {
                value = GetObject((Dictionary<string, object>) value, prop.PropertyType); // <= This line
            }

         

            prop.SetValue(obj,Convert.ChangeType(value, prop.PropertyType), null);
        }
        return obj;
    }
    
    public static T GetObject<T>(Dictionary<string, object> dict)
    {
        return (T)GetObject(dict, typeof(T));
    }
    
    
    public static IDictionary<string, string> ToDictionary(IFormCollection col)
    {
        var dict = new Dictionary<string, string>();

        foreach (var key in col.Keys)
        {
            dict.Add(key, col[key]);
        }

        return dict;
    }
    public static Dictionary<string, object> ToLog(object obj, string action = "")
    {
        var dictionary = new Dictionary<string, object>();

        if (obj != null)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            if (string.IsNullOrEmpty(action))
            {
                dictionary["action"] = type.Name.ToUpper();
            }
            else
            {
                dictionary["action"] = action.ToUpper();
            }

            foreach (PropertyInfo property in properties)
            {
                var maskedAttribute = property.GetCustomAttribute<MaskedAttribute>();
                // Check for the JsonProperty attribute
                JsonPropertyAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                string key = jsonPropertyAttribute != null ? jsonPropertyAttribute.PropertyName : property.Name;

                if (key == "action")
                {
                    continue;
                }

                object value = property.GetValue(obj, null);
                if (maskedAttribute != null && value != null)
                {
                    value = (object)Cryptographer.Mask(value.ToString());
                }
                dictionary[key] = value;
            }
        }

        return dictionary;
    }
    public static object ConvertType(object value, PropertyInfo propertyInfo)
    {
        if (propertyInfo == null)
        {
            throw new ArgumentNullException(nameof(propertyInfo));
        }
        

        if (value == null)
        {
            // Handle null values according to your requirements
            return null;
        }
        
        
        
        string strValue = value.ToString();

        // Check if the string starts and ends with the same type of quote
        if ((strValue.StartsWith("\"") && strValue.EndsWith("\"")) || (strValue.StartsWith("'") && strValue.EndsWith("'")))
        {
            // Trim the quotes
            strValue = strValue.Substring(1, strValue.Length - 2);

            // Handle escaping within the string
            strValue = strValue.Replace("\\\"", "\"").Replace("\\'", "'");

            value = strValue;
        }
        
        var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
        Type targetType;

        if (underlyingType != null)
        {
            if (value == "")
            {
                return null;
            }
        }

        if (underlyingType != null)
        {
            targetType = underlyingType;
            
        }
        else
        {
            targetType = propertyInfo.PropertyType;
        }
        
        
        if (targetType == typeof(bool))
        {
            // Special handling for bool properties
            if (string.IsNullOrEmpty(value.ToString()) || value.ToString() == "0")
            {
                return false;
            }

            if (int.TryParse(value.ToString(), out int intValue) && intValue > 0)
            {
                return true;
            }
        }
        else if (targetType == typeof(int))
        {
            if (underlyingType != null && (string.IsNullOrEmpty(value.ToString()) || value.ToString() == "0"))
            {
                return null;
            }
            // Special handling for int properties
            if (int.TryParse(value.ToString().Trim('\'', '"'), out int intValue))
            {
                return intValue;
            }

            return 0;

            // Handle the case where parsing fails (e.g., non-integer value)
            // You can throw an exception or handle it differently as needed
            //throw new ArgumentException($"Unable to parse value as {targetType.Name}", nameof(value));
        }

        if (targetType.IsInstanceOfType(value))
        {
            // No conversion needed if the types are already compatible
            return value;
        }

        // Use Convert.ChangeType to perform type conversion
        try
        {
            return Convert.ChangeType(value, targetType);
        }
        catch (Exception)
        {
            //var x = new { targetType };
            //return x;
            // Handle conversion failures according to your requirements
            return null;
            throw new ArgumentException($"Unable to convert value to {targetType.Name}", nameof(value));
        }
    }
    
    
    public static T Clone<T>(T source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        Type type = source.GetType();
        T target = (T)Activator.CreateInstance(type);

        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.CanRead && property.CanWrite)
            {
                object value = property.GetValue(source);
                property.SetValue(target, value);
            }
        }

        return target;
    }
    
    public static Dictionary<string, string> ParseHtmlForm(string html)
    {
        var formData = new Dictionary<string, string>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Find the form element
        var formElement = doc.DocumentNode.SelectSingleNode("//form");

        if (formElement != null)
        {
            // Iterate through input elements within the form
            foreach (var inputElement in formElement.SelectNodes(".//input"))
            {
                string name = inputElement.GetAttributeValue("name", "");
                string value = inputElement.GetAttributeValue("value", "");

                formData[name] = value;
            }
        }


      

        return formData;
    }
    
    
    public static string GetDecodedHtmlContent(string htmlContent) => Encoding.UTF8.GetString(Convert.FromBase64String(htmlContent));


    public static Dictionary<string, string> ToDictionary(this HttpRequest httpRequest)
    {
        Dictionary<string, string> requestDict = new Dictionary<string, string>();
        
        foreach (var formField in httpRequest.Form)
        {
            requestDict[formField.Key] = formField.Value;
        }
        
        foreach (var queryParam in httpRequest.Query)
        {
            requestDict[queryParam.Key] = queryParam.Value;
        }

        return requestDict;

    }
    
    
    public static  T BindFormToModel<T>(Dictionary<string, string> form)
    {
        var model = Activator.CreateInstance<T>();
        var properties = typeof(T).GetProperties();
        
        var lowerCaseForm = new Dictionary<string, string>();

        foreach (var kvp in form)
        {
            string lowerCaseKey = kvp.Key.ToLower();
            lowerCaseForm[lowerCaseKey] = kvp.Value;
        }


        foreach (var property in properties)
        {
            var propertyName = property.Name;
            if (property.Name.StartsWith("__"))
            {
                propertyName = propertyName.Substring(2);
            }

            string propertyNameLowerCase = propertyName.ToLower();
            
            if (lowerCaseForm.ContainsKey(propertyNameLowerCase)) // Check if there's at least one value
            {
                var formValue = lowerCaseForm[propertyNameLowerCase];
                var propertyType = property.PropertyType;

                if (propertyType == typeof(int))
                {
                    if (int.TryParse(formValue, out int intValue))
                    {
                        property.SetValue(model, intValue);
                    }
                }
                else if (propertyType == typeof(decimal))
                {
                    if (decimal.TryParse(formValue, out decimal decimalValue))
                    {
                        property.SetValue(model, decimalValue);
                    }
                }
                else
                {
                    property.SetValue(model, formValue);
                }
            }
        }

        return model;
    }
    
    
    public static T CastInto<T>(object obj)
    {
        return (T)obj; 
        // return obj as T; // if you want to perform safe casting and you are ok with possible null values. Adding type constraint (e.g. where T : class) is needed to use it.
    }


    
    
    
    
}