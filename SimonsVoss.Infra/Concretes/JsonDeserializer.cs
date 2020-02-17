using Newtonsoft.Json;
using SimonsVoss.Infra.Interfaces;

namespace SimonsVoss.Infra.Concretes
{
    public class JsonDeserializer : IDeserializer
    {
        public T Deserialize<T>(string stringToDeserialize)
        {
            var jsonSeriallizerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
            return JsonConvert.DeserializeObject<T>(stringToDeserialize, jsonSeriallizerSettings);
        }
    }
}
