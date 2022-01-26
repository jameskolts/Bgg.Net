using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Http;
using System.Xml.Serialization;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Xml;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;


namespace Bgg.Net.Common.Resources.Things
{
    public class ThingHandler : IThingHandler
    {
        private readonly BggClient _client;

        public ThingHandler(BggClient bggClient)
        {
            _client = bggClient;
        }

        public async Task<BggResult<Thing>> GetThingById(int id)
        {
            var httpResponseMessage = await _client.GetAsync($"thing?id={id}&versions=1&comments=1");
            var aThingString = await httpResponseMessage.Content.ReadAsStringAsync();          
            

            var aThing = new ThingDeserializer("//items/item").Deserialize(aThingString); 

            try
            {

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return new BggResult<Thing>();
        }

        public async Task<BggResult<Thing>> GetThingsExtensible(List<Extension> extensions)
        {
            throw new NotImplementedException();
        }

        public Task<BggResult<Thing>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
