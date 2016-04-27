using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class SystemService
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        [Obsolete("Please use EslClient")]
        public SystemService(RestClient restClient, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            Json.JsonSerializerSettings = jsonSerializerSettings;
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
        }
        internal SystemService(RestClient restClient, string baseUrl)
        {
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
        }

        public string GetApplicationVersion() 
        {
            var path = _template.UrlFor(UrlTemplate.SYSTEM_PATH)
                .Build();

            try
            {
                var response = _restClient.Get(path);
                var systemInfo = Json.DeserializeWithSettings<Dictionary<string, string>>(response);
                return systemInfo["version"];
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get application version." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get application version." + " Exception: " + e.Message, e);
            }
        }
    }
}

