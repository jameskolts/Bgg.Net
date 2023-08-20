using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Deserialization
{
    /// <summary>
    /// Public interface for the DeserializerFactory
    /// </summary>
    public interface IDeserializerFactory
    {
        /// <summary>
        /// Create an instance of <see cref="IDeserializer"/>.
        /// </summary>
        /// <param name="format">The type of deserializer to create.</param>
        /// <returns>The <see cref="IDeserializer"/> for the given format.</returns>
        IDeserializer Create(DeserializationFormat format);

        /// <summary>
        /// Create an instance of <see cref="IDeserializer"/>.
        /// </summary>
        /// <param name="type">The type of the object being deserialized.</param>
        /// <returns>An implementation of <see cref="XmlDeserializer"/> if the type inherits from BggBase,
        /// otherwise <see cref="JsonDeserializer"/>
        /// </returns>
        IDeserializer Create(Type type);
    }
}
