using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class Json
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonSerializerSettings SerializerSettings
        {
            get
            {
                return _jsonSerializerSettings;
            }
        }
        public Json(JsonSerializerSettings serializerSettings)
        {
            _jsonSerializerSettings = serializerSettings;
        }
        public Json()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            _jsonSerializerSettings.Converters.Add(new CultureInfoJsonCreationConverter());
        }

        public T DeserializeWithSettings<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public string SerializeWithSettings(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public string Serialize(object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T Deserialize<T>(string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
