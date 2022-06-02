namespace Bgg.Net.Common.Infrastructure.Extensions
{
    /// <summary>
    /// Contains extensions for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalizes the first char of a string.
        /// </summary>
        /// <param name="str">The string to capitalize.</param>
        /// <returns>The string with the first char capitalized.</returns>
        public static string UpperFirstChar(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            return char.ToUpper(str[0]) + str[1..];
        }
    }
}
