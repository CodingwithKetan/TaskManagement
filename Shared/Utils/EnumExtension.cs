using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils
{
    public static class EnumExtension
    {
        public static TEnum ToEnumOrDefault<TEnum>(this string valueToParse, TEnum defaultValue) where TEnum : struct
        {
            return Enum.TryParse<TEnum>(
                valueToParse,
                true,
                out var parsedValue)
                ? parsedValue
                : defaultValue;
        }

        public static bool IsValidEnum<TEnum>(this string valueToParse, bool ignoreCase = true) where TEnum : struct
        {
            return Enum.TryParse<TEnum>(valueToParse, ignoreCase, out _);
        }
    }
}
