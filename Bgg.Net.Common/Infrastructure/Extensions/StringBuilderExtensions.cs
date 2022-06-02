using System.Collections;
using System.Text;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendBoolProp(this StringBuilder stringBuilder, string propName, bool? value)
        {
            if (value.HasValue)
            {
                stringBuilder.AppendPropName(propName);

                if (value == true)
                {
                    stringBuilder.Append('1');
                }
                else
                {
                    stringBuilder.Append('0');
                }
            }

            return stringBuilder;
        }

        public static StringBuilder AppendDateOnlyProp(this StringBuilder stringBuilder, string propName, DateOnly? value)
        {
            if (value.HasValue)
            {
                stringBuilder.AppendPropName(propName);
                stringBuilder.Append(value.Value.ToString("yyyy-MM-dd"));
            }

            return stringBuilder;
        }

        public static StringBuilder AppendDateTimeProp(this StringBuilder stringBuilder, string propName, DateTime? value)
        {
            if (value.HasValue)
            {
                stringBuilder.AppendPropName(propName);
                stringBuilder.Append(value.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return stringBuilder;
        }

        public static StringBuilder AppendListProp(this StringBuilder stringBuilder, string propName, IList valueList)
        {
            if (valueList.Count > 0)
            {
                stringBuilder.AppendPropName(propName);
                for (int i = 0; i < valueList.Count; i++)
                {
                    if (i == 0)
                    {
                        stringBuilder.Append(valueList[i].ToString().ToLower());
                    }
                    else
                    {
                        stringBuilder.Append("," + valueList[i].ToString().ToLower());
                    }
                }
            }

            return stringBuilder;
        }

        public static StringBuilder AppendPropName(this StringBuilder stringBuilder, string propName)
        {
            if (stringBuilder[^1] != '?' &&
                stringBuilder[^1] != '&')
            {
                stringBuilder.Append('&');
            }

            stringBuilder.Append(propName);
            stringBuilder.Append('=');

            return stringBuilder;
        }
    }
}
