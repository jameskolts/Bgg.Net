namespace Bgg.Net.Common.Infrastructure.Deserialization
{
    public interface IDeserializer
    {
        T Deserialize<T>(string textContent)
            where T : class;
    }
}
