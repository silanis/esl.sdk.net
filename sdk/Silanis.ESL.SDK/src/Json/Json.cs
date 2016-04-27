using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class Json
    {
        private static JsonSerializerSettings _jsonSerializerSettings;

        public static JsonSerializerSettings SerializerSettings
        {
            set
            {
                if(value != null)
                    _jsonSerializerSettings = value;
            }
            get
            {
                if (_jsonSerializerSettings == null)
                {
                    _jsonSerializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc
                    };
                    _jsonSerializerSettings.Converters.Add(new CultureInfoJsonCreationConverter());
                    
                }
                return _jsonSerializerSettings;
            }   
        }

        public static T DeserializeWithSettings<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, SerializerSettings);
        }

        public static string SerializeWithSettings(object obj)
        {
            return JsonConvert.SerializeObject(obj, SerializerSettings);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string Serialize(object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T Deserialize<T>(string json, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
