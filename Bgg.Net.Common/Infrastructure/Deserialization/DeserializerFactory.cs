using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Bgg.Net.Common.Infrastructure.Deserialization
{
    public class DeserializerFactory : IDeserializerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DeserializerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDeserializer Create(DeserializationFormat format)
        {
            return format switch
            {
                DeserializationFormat.Json => _serviceProvider.GetRequiredService<JsonDeserializer>(),
                DeserializationFormat.Xml => _serviceProvider.GetRequiredService<XmlDeserializer>(),
                _ => throw new NotImplementedException($"Unable to create deserializer for {format}")
            };
        }

        public IDeserializer Create(Type type)
        {
            if (type.IsSubclassOf(typeof(BggBase)))
            {
                return Create(DeserializationFormat.Xml);
            }

            return Create(DeserializationFormat.Json);
        }
    }
}
