namespace StringTrimmer;

using System.Linq;
using System.Reflection;

public static class ClassTrimmerExtension
{
    public static T? TrimExtraSpaces<T>(this T? obj, ClassTrimmerOptions options = ClassTrimmerOptions.None) where T : class
    {
        return obj.HandleAllStrings((str) => str.Trim().RemoveConsecutiveSpaces(), options);
    }
    public static T? TrimAllString<T>(this T? obj, Func<string, string> func, ClassTrimmerOptions options = ClassTrimmerOptions.None) where T : class
    {
        return obj.HandleAllStrings((str) => func(str), options);
    }

    public static T? TrimAllStrings<T>(this T? obj, ClassTrimmerOptions options = ClassTrimmerOptions.None) where T : class
    {
        return obj.HandleAllStrings((str) => str.Trim(), options);
    }

    public static T? TrimAllStringEnd<T>(this T? obj, ClassTrimmerOptions options = ClassTrimmerOptions.None) where T : class
    {
        return obj.HandleAllStrings((str) => str.TrimEnd(), options);
    }

    public static T? TrimAllStringStart<T>(this T? obj, ClassTrimmerOptions options = ClassTrimmerOptions.None) where T : class
    {
        return obj.HandleAllStrings((str) => str.TrimStart(), options);
    }

    public static string RemoveConsecutiveSpaces(this string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        var lenght = s.Length;
        var characters = s.ToCharArray();
        int lastChar = 0;
        var spaceAdded = false;
        for (int i = 0; i < lenght; i++)
        {
            var ch = characters[i];

            if (char.IsWhiteSpace(ch))
            {
                if (spaceAdded)
                {
                    continue;
                }
                spaceAdded = true;
            }
            else
            {
                spaceAdded = false;
            }

            characters[lastChar++] = ch;

        }
        return new string(characters, 0, lastChar);
    }

    internal static T? HandleAllStrings<T>(this T? obj, Func<string, string> trimmer, ClassTrimmerOptions options) where T : class
    {
        if (obj == null)
        {
            return null;
        }

        var objType = obj.GetType();
        var key = options + objType.FullName;

        var stringProperties = obj.GetType()
              .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
              .Where(pi => pi.PropertyType == typeof(string));

        if (!options.HasFlag(ClassTrimmerOptions.TrimPrivateProperties))
        {
            stringProperties = stringProperties.Where(pi => pi.GetSetMethod(false) != null);
        };

        foreach (var stringProperty in stringProperties)
        {
            var val = stringProperty.GetValue(obj) as string;
            if (val != null) { val = trimmer(val); }
            stringProperty.SetValue(obj, val, null);
        }

        return obj;
    }
}

