using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils
{
    public static class StringExtension
    {
        public static bool IsBlank(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotBlank(this string value)
        {
            return !IsBlank(value);
        }

        public static string JoinUsing(this IEnumerable<string> values, string joiner)
        {
            if (values == null)
            {
                return null;
            }

            return string.Join(joiner, values);
        }
    }
}
