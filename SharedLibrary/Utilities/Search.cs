using System.Reflection;

namespace SharedLibrary.Utilities;

public class Search
{
    public static string FindPropertyNameByValue(Type type, object valueToFind)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (PropertyInfo property in properties)
        {
            object propertyValue = property.GetValue(type);
            if (propertyValue != null && propertyValue.Equals(valueToFind))
            {
                return property.Name;
            }
        }
        
        return null;
    }

    public static object? FindPropertyValueByName(Type type, string propertyName)
    {
        
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        
        PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);

        if (propertyInfo != null)
        {
            object propertyValue = propertyInfo.GetValue(type);

            return propertyValue;
        }


        return null;
    }
}