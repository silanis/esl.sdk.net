using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class LayoutApiClient
    {
        private UrlTemplate template;
        private RestClient restClient;
        private JsonSerializerSettings settings;

        public LayoutApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            template = new UrlTemplate(baseUrl);
            this.restClient = restClient;
            this.settings = settings;
        }

        public string CreateLayout(Package layoutPackage, String packageId)
        {
            var path = template.UrlFor(UrlTemplate.LAYOUT_PATH)
                .Build();

            var packageJson = JsonConvert.SerializeObject(layoutPackage, settings);
            var apiTemplate = JsonConvert.DeserializeObject<Silanis.ESL.API.Template>(packageJson, settings);
            apiTemplate.Id = packageId;
            var templateJson = JsonConvert.SerializeObject(apiTemplate, settings);

            try
            {
                var response = restClient.Post(path, templateJson);
                var aPackage = JsonConvert.DeserializeObject<Silanis.ESL.API.Package>(response, settings);
                return aPackage.Id;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not create layout." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not create layout." + " Exception: " + e.Message, e);
            }
        }

        public Result<Package> GetLayouts(Direction direction, PageRequest request)
        {
            var path = template.UrlFor(UrlTemplate.LAYOUT_LIST_PATH)
                .Replace("{dir}", DirectionUtility.getDirection(direction))
                .Replace("{from}", request.From.ToString())
                .Replace("{to}", request.To.ToString())
                .Build();

            try
            {
                var response = restClient.Get(path);
                return JsonConvert.DeserializeObject<Result<Silanis.ESL.API.Package>>(response, settings);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get list of layouts." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get list of layouts." + " Exception: " + e.Message, e);
            }
        }

        public void ApplyLayout(string packageId, string documentId, string layoutId)
        {
            var path = template.UrlFor(UrlTemplate.APPLY_LAYOUT_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{layoutId}", layoutId)
                .Build();

            try
            {
                restClient.Post(path, "");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not apply layout." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not apply layout." + " Exception: " + e.Message, e);
            }
        }

    }
}

