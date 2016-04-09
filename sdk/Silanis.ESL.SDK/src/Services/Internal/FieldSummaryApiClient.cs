using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    internal class FieldSummaryApiClient
    {
        private readonly string _apiToken;
        private readonly UrlTemplate _template;

         public FieldSummaryApiClient (string apiToken, string baseUrl)
        {
            _apiToken = apiToken;
            _template = new UrlTemplate (baseUrl);                                                                   
        }
        
        public List<FieldSummary> GetFieldSummary (string packageId)
        {
            var path = _template.UrlFor (UrlTemplate.FIELD_SUMMARY_PATH)
                            .Replace ("{packageId}", packageId)
                            .Build ();

            try {
                var response = Converter.ToString (HttpMethods.GetHttp (_apiToken, path));
                return Json.Deserialize<List<FieldSummary>> (response);
            }
            catch (EslServerException e) {
                throw new EslServerException ("Could not get the field summary." + " Exception: " + e.Message,e.ServerError,e);
            }
            catch (Exception e) {
                throw new EslException ("Could not get the field summary." + " Exception: " + e.Message,e);
            }
        }
    }
}

