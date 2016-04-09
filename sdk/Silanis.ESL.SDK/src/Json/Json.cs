using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class Json
    {
        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };
                serializerSettings.Converters.Add(new CultureInfoJsonCreationConverter());
                return serializerSettings;
            }   
        }

        public static T DeserializeWithSettings<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
        }

        public static string SerializeWithSettings(object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonSerializerSettings);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }


    }
}
