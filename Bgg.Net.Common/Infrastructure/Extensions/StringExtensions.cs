namespace Bgg.Net.Common.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string UpperFirstChar(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
