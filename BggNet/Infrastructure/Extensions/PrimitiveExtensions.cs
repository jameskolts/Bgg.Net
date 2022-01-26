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

        public static DateTime? ToNullabeDateTime(this string s)
        {
            if (DateTime.TryParse(s, out DateTime i))
            {
                return i;
            }

            return null;
        }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null:
                    throw new ArgumentNullException(nameof(input));
                case "":
                    throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default:
                    return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
            }
        }
    }
}
