using Bgg.Net.Common.Models.Requests;
using System.Collections;
using System.Text;

namespace Bgg.Net.Common.Infrastructure
{
    public class QueryBuilder : IQueryBuilder
    {
        public string BuildQuery(string resourceName, BggRequest request)
        {
            var stringBuilder = new StringBuilder();

            var type = request.GetType();
            var propInfo = type.GetProperties();

            stringBuilder.Append($"{resourceName}?");

            foreach (var prop in propInfo)
            {
                var pi = type.GetProperty(prop.Name);

                if (pi.GetValue(request) != null)
                {
                    if (!stringBuilder.ToString().EndsWith('?'))
                    {
                        stringBuilder.Append('&');
                    }
                    stringBuilder.Append(prop.Name.ToLower());
                    stringBuilder.Append('=');

                    if (pi.PropertyType == typeof(bool?))
                    {
                        var paramValue = pi.GetValue(request, null) as bool?;

                        if (paramValue == true)
                        {
                            stringBuilder.Append('1');
                        }
                        else
                        {
                            stringBuilder.Append('0');
                        }
                    }
                    else if (pi.PropertyType == typeof(DateOnly?))
                    {
                        var paramValue = pi.GetValue(request, null) as DateOnly?;

                        stringBuilder.Append(paramValue.Value.ToString("yyyy-MM-dd"));
                    }
                    else if (pi.PropertyType == typeof(DateTime?))
                    {
                        var paramValue = pi.GetValue(request, null) as DateTime?;

                        stringBuilder.Append(paramValue.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else if (pi.PropertyType.Name.StartsWith("List"))
                    {
                        var paramList = pi.GetValue(request, null) as IList;

                        for (int i = 0; i < paramList.Count; i++)
                        {
                            if (i == 0)
                            {
                                stringBuilder.Append(paramList[i].ToString().ToLower());
                            }
                            else
                            {
                                stringBuilder.Append("," + paramList[i].ToString().ToLower());
                            }
                        }
                    }
                    else
                    {
                        stringBuilder.Append(pi.GetValue(request, null).ToString().ToLower());
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
