using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml.Interfaces
{
    public interface IBggDeserializer
    {
        T Deserialize<T>(string xml)
            where T : BggBase;

        List<T> DeserializeList<T>(string xml)
            where T : BggBase;
    }
}
