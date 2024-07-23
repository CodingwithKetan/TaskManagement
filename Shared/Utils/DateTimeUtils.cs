using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils
{
    public class DateTimeUtils
    {
        public static DateTime GetCurrentTimeInUTC() { 
            return DateTime.UtcNow;
        }
    }
}
