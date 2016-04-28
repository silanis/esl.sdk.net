using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class EventNotificationApiClient
    {
        private readonly RestClient _restClient;
        private readonly UrlTemplate _template;
        private readonly Json _json;

        [Obsolete("Please use EslClient")]
        public EventNotificationApiClient(RestClient restClient, string apiUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            _json = new Json(jsonSerializerSettings);
            _restClient = restClient;
            _template = new UrlTemplate(apiUrl);
        }
        internal EventNotificationApiClient(RestClient restClient, string apiUrl)
        {
            _json = new Json();
            _restClient = restClient;
            _template = new UrlTemplate(apiUrl);
        }
        
        public void Register(Callback callback)
        {
            try
            {
                var path = _template.UrlFor(UrlTemplate.CALLBACK_PATH).Build();
                var json = _json.SerializeWithSettings(callback);

                _restClient.Post(path, json);
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
                var path = _template.UrlFor(UrlTemplate.CONNECTORS_CALLBACK_PATH)
                    .Replace("{origin}", origin)
                    .Build();
                var json = _json.SerializeWithSettings(callback);

                _restClient.Post(path, json);
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
            var path = _template.UrlFor(UrlTemplate.CALLBACK_PATH).Build();

            try
            {
                var stringResponse = _restClient.Get(path);
                return _json.DeserializeWithSettings<Callback>(stringResponse);
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
            var path = _template.UrlFor(UrlTemplate.CONNECTORS_CALLBACK_PATH)
                .Replace("{origin}", origin)
                .Build();

            try
            {
                var stringResponse = _restClient.Get(path);
                return _json.DeserializeWithSettings<Callback>(stringResponse);
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

