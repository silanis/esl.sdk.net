using System;
using System.Globalization;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class LayoutApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        public LayoutApiClient(RestClient restClient, string baseUrl)
        {
            _template = new UrlTemplate(baseUrl);
            _restClient = restClient;
        }

        public string CreateLayout(Package layoutPackage, String packageId)
        {
            var path = _template.UrlFor(UrlTemplate.LAYOUT_PATH)
                .Build();

            var packageJson = Json.SerializeWithSettings(layoutPackage);
            var apiTemplate = Json.DeserializeWithSettings<Template>(packageJson);
            apiTemplate.Id = packageId;
            var templateJson = Json.SerializeWithSettings(apiTemplate);

            try
            {
                var response = _restClient.Post(path, templateJson);
                var aPackage = Json.DeserializeWithSettings<Package>(response);
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
            var path = _template.UrlFor(UrlTemplate.LAYOUT_LIST_PATH)
                .Replace("{dir}", DirectionUtility.getDirection(direction))
                .Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
                .Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
                .Build();

            try
            {
                var response = _restClient.Get(path);
                return Json.DeserializeWithSettings<Result<Package>>(response);
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
            var path = _template.UrlFor(UrlTemplate.APPLY_LAYOUT_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{layoutId}", layoutId)
                .Build();

            try
            {
                _restClient.Post(path, "");
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

