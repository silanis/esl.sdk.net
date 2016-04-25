using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class SigningService
    {
        private UrlTemplate template;
        private RestClient restClient;
        private JsonSerializerSettings settings;

        public SigningService(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.template = new UrlTemplate( baseUrl );
            this.restClient = restClient;
            this.settings = settings;
        }

        internal void SignDocument( PackageId packageId, Silanis.ESL.API.Document document ) 
        {
            string path = template.UrlFor( UrlTemplate.SIGN_DOCUMENT_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                string json = JsonConvert.SerializeObject(document, settings);
                restClient.Post( path, json );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign document." + " Exception: " + e.Message, e);
            }
        }

        internal void SignDocuments( PackageId packageId, Silanis.ESL.API.SignedDocuments documents ) 
        {
            string path = template.UrlFor( UrlTemplate.SIGN_DOCUMENTS_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                string json = JsonConvert.SerializeObject(documents, settings);
                restClient.Post( path, json );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign documents." + " Exception: " + e.Message, e);
            }
        }

        internal void SignDocuments( PackageId packageId, Silanis.ESL.API.SignedDocuments documents, string signerSessionId ) 
        {
            string path = template.UrlFor( UrlTemplate.SIGN_DOCUMENTS_PATH )
                .Replace("{packageId}", packageId.Id)
                .Build();

            try 
            {
                string json = JsonConvert.SerializeObject(documents, settings);
                restClient.Post( path, json, signerSessionId );
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not sign documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not sign documents." + " Exception: " + e.Message, e);
            }
        }
    }
}

