using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Models.Requests;
using System.Collections;
using System.Text;

namespace Bgg.Net.Common.Infrastructure
{

    public class QueryBuilder : IQueryBuilder
    {
        /// <inheritdoc/>
        public string BuildQuery(string resourceName, BggRequest request)
        {
            var stringBuilder = new StringBuilder();

            var type = request.GetType();
            var properties = type.GetProperties();

            stringBuilder.Append($"{resourceName}?");

            foreach (var prop in properties)
            {
                var propInfo = type.GetProperty(prop.Name);
                var propName = prop.Name.ToLower();

                if (propInfo.GetValue(request) != null)
                {
                    if (propInfo.PropertyType == typeof(bool?))
                    {
                        stringBuilder.AppendBoolProp(propName, propInfo.GetValue(request, null) as bool?);
                    }
                    else if (propInfo.PropertyType == typeof(DateOnly?))
                    {
                        stringBuilder.AppendDateOnlyProp(propName, propInfo.GetValue(request, null) as DateOnly?);
                    }
                    else if (propInfo.PropertyType == typeof(DateTime?))
                    {
                        stringBuilder.AppendDateTimeProp(propName, propInfo.GetValue(request, null) as DateTime?);
                    }
                    else if (propInfo.PropertyType.Name.StartsWith("List"))
                    {
                        stringBuilder.AppendListProp(propName, propInfo.GetValue(request, null) as IList);
                    }
                    else
                    {
                        stringBuilder.AppendPropName(propName);
                        stringBuilder.Append(propInfo.GetValue(request, null).ToString().ToLower());
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
