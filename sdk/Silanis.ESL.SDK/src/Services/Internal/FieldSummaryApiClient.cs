using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    internal class FieldSummaryApiClient
    {
        private string apiToken;
        private UrlTemplate template;

         public FieldSummaryApiClient (string apiToken, string baseUrl)
        {
            this.apiToken = apiToken;
            template = new UrlTemplate (baseUrl);                                                                   
        }
        
        public List<FieldSummary> GetFieldSummary (string packageId)
        {
            var path = template.UrlFor (UrlTemplate.FIELD_SUMMARY_PATH)
                            .Replace ("{packageId}", packageId)
                            .Build ();

            try {
                var response = Converter.ToString (HttpMethods.GetHttp (apiToken, path));
                return JsonConvert.DeserializeObject<List<FieldSummary>> (response);
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

