using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Silanis.ESL.API
{
    public class UnknownEnumValuesHandleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
            return type.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullable = IsNullableType(objectType);
            var enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            var names = Enum.GetNames(enumType);
            string match = null;
            if (reader.TokenType == JsonToken.String)
            {
                var enumText = reader.Value.ToString();

                if (!string.IsNullOrEmpty(enumText))
                {
                    match = GetMatchedName(enumText, names);

                    if (match != null)
                    {
                        return Enum.Parse(enumType, match);
                    }
                }
            }
            if (!isNullable)
            {
                if (match == null && names != null && names.Length > 0)
                {
                    match = names[0];
                }

                return Enum.Parse(enumType, match);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        private string GetMatchedName(string enumText, string[] names)
        {
            string matchedName = null;
            if (names != null && names.Length > 0)
            {
                matchedName = names[0];
            }
            foreach(var name in names)
            {
                if(string.Equals(enumText, name, StringComparison.OrdinalIgnoreCase))
                {
                    matchedName = name;
                }
            }
            return matchedName;
        }

        private bool IsNullableType(Type t)
        {
            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}

