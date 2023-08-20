using System.ComponentModel.DataAnnotations;

namespace Bgg.Net.Common.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireNonDefaultAttribute : ValidationAttribute
    {
        public RequireNonDefaultAttribute()
            : base("The {0} field requires a non-default value.")
        {
        }

        public override bool IsValid(object value)
        {
            if (value is null)
                return true;
            var type = value.GetType();

            if (type == typeof(string))
            {
                return !string.IsNullOrWhiteSpace(value as string);
            }

            return !Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type));
        }
    }
}
