using System.ComponentModel;
using System.Reflection;

namespace Core.Utilities.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    public static T ParseEnum<T>(string value) where T : struct
    {
        return Enum.TryParse<T>(value, true, out var result) ? result : default;
    }

    public static List<T> GetEnumValues<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }
}