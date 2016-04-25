using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Silanis.ESL.SDK
{
    public class CultureInfoJsonCreationConverter : JsonCreationConverter<CultureInfo>
    {
        protected override CultureInfo Create(Type objectType, JObject jObject)
        {
            string jsonString = jObject.ToString();
            return new CultureInfo( jsonString );
        }
    }
}

