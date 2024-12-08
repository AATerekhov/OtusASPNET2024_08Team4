using System.Globalization;

namespace MagazineHost.Helpers
{
    public static class DateTimeHelper
    {
        public const string DateFormat = "MM/dd/yyyy";

        public static string ToDateString(this DateTime date, string format = DateFormat)
            => date.ToString(format);

        public static DateTime ToDateTime(this string date, string format = DateFormat)
            => DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
    }
}
