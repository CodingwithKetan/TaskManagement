

namespace Shared.CommonModels
{
    public enum DateRange
    {
        Weekly,
        Monthly,
        FifteenDays
    }

    public static class DateRangeExtensions
    {
        public static DateTime CalculateDueDate(this DateRange dateRange)
        {
            switch (dateRange)
            {
                case DateRange.Weekly:
                    return DateTime.Now.AddDays(7);
                case DateRange.Monthly:
                    return DateTime.Now.AddMonths(1);
                case DateRange.FifteenDays:
                    return DateTime.Now.AddDays(15);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateRange), dateRange, null);
            }
        }
    }

}
