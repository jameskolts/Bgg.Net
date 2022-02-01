namespace Bgg.Net.Common.Infrastructure.Extensions
{
    public static class PrimitiveExtensions
    {
        public static int? ToNullableInt(this string s)
        {
            if (int.TryParse(s, out int i))
            {
                return i;
            }

            return null;
        }

        public static double? ToNullableDouble(this string s)
        {
            if (double.TryParse(s, out double i))
            {
                return i;
            }

            return null;
        }

        public static long? ToNullableLong(this string s)
        {
            if (long.TryParse(s, out long i))
            {
                return i;
            }

            return null;
        }

        public static DateTime? ToNullableDateTime(this string s)
        {
            if (DateTime.TryParse(s, out DateTime i))
            {
                return i;
            }

            return null;
        }

        public static DateTimeOffset? ToNullableDateTimeOffset(this string s)
        {
            if (DateTimeOffset.TryParse(s, out DateTimeOffset i))
            {
                return i;
            }

            return null;
        }

        public static bool? ToNullableBool(this string s)
        {
            switch (s?.ToLower())
            {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    return null;
            }
        }
    }
}
