using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class EventNotificationApiClient
    {
        private RestClient restClient;
        private UrlTemplate template;
        private JsonSerializerSettings settings;

        public EventNotificationApiClient(RestClient restClient, string apiUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate(apiUrl);
            this.settings = settings;
        }
        
        public void Register(Callback callback)
        {
            try
            {
                var path = template.UrlFor(UrlTemplate.CALLBACK_PATH).Build();
                var json = JsonConvert.SerializeObject(callback, settings);

                restClient.Post(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException( "Unable to configure event notification. " + e.Message, e.ServerError, e);
            }
            catch (EslException e)
            {
                throw new EslException("Unable to configure event notification. " + e.Message, e);
            }
        }

        public void Register(string origin, Callback callback)
        {
            try
            {
                var path = template.UrlFor(UrlTemplate.CONNECTORS_CALLBACK_PATH)
                    .Replace("{origin}", origin)
                    .Build();
                var json = JsonConvert.SerializeObject(callback, settings);

                restClient.Post(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException( "Unable to configure event notification for this connector. " + e.Message, e.ServerError, e);
            }
            catch (EslException e)
            {
                throw new EslException("Unable to configure event notification for this connector. " + e.Message, e);
            }
        }

        public Callback GetEventNotificationConfig()
        {
            var path = template.UrlFor(UrlTemplate.CALLBACK_PATH).Build();

            try
            {
                var stringResponse = restClient.Get(path);
                return JsonConvert.DeserializeObject<Callback>(stringResponse, settings);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not retrieve event notification. " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not retrieve event notification. " + e.Message, e);
            }
        }

        public Callback GetEventNotificationConfig(string origin)
        {
            var path = template.UrlFor(UrlTemplate.CONNECTORS_CALLBACK_PATH)
                .Replace("{origin}", origin)
                .Build();

            try
            {
                var stringResponse = restClient.Get(path);
                return JsonConvert.DeserializeObject<Callback>(stringResponse, settings);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not retrieve event notification for this connector. " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not retrieve event notification for this connector. " + e.Message, e);
            }
        }
    }
}

