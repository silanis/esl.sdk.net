using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class SystemService
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;

        public SystemService(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate(baseUrl);
            this.settings = settings;
        }

        public string GetApplicationVersion() 
        {
            var path = template.UrlFor(UrlTemplate.SYSTEM_PATH)
                .Build();

            try
            {
                var response = restClient.Get(path);
                var systemInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(response, settings);
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

