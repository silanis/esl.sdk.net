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
        private readonly Json _json;

        [Obsolete("Please use EslClient")]
        public SystemService(RestClient restClient, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            _json = new Json(jsonSerializerSettings);
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
        }
        internal SystemService(RestClient restClient, string baseUrl)
        {
            _json = new Json();
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
                var systemInfo = _json.DeserializeWithSettings<Dictionary<string, string>>(response);
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

