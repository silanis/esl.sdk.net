using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class TemplateApiClient
    {
        private UrlTemplate urls;
        private JsonSerializerSettings settings;
        private RestClient restClient;
        
        internal TemplateApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            urls = new UrlTemplate (baseUrl);
            this.settings = settings;
        }
        
        internal string CreateTemplateFromPackage(string originalPackageId, Silanis.ESL.API.Package delta)
        {
            delta.Type = "TEMPLATE";
            string path = urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", originalPackageId)
                .Build ();
            try {
                string deltaJson = JsonConvert.SerializeObject (delta, settings);
                string response = restClient.Post(path, deltaJson);              
                Silanis.ESL.API.Package apiResult = JsonConvert.DeserializeObject<Silanis.ESL.API.Package> (response);
                return apiResult.Id;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create a template." + " Exception: " + e.Message, e.ServerError, e);
            } catch (Exception e) {
                throw new EslException ("Could not create a template." + " Exception: " + e.Message, e);
            }
        }
        
        internal string CreatePackageFromTemplate(string templateId, Silanis.ESL.API.Package delta)
        {
            string path = urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", templateId)
                .Build ();
            try {
                string deltaJson = JsonConvert.SerializeObject (delta, settings);
                string response = restClient.Post(path, deltaJson);              
                Silanis.ESL.API.Package apiResult = JsonConvert.DeserializeObject<Silanis.ESL.API.Package> (response);
                return apiResult.Id;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create a package from template." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Could not create a package from template." + " Exception: " + e.Message, e);
            }
        }
        
        internal string CreateTemplate(Silanis.ESL.API.Package template)
        {
            string path = urls.UrlFor(UrlTemplate.PACKAGE_PATH).Build();

            try
            {
                string json = JsonConvert.SerializeObject(template, settings);
                string response = restClient.Post(path, json);
                Silanis.ESL.API.Package apiPackage = JsonConvert.DeserializeObject<Silanis.ESL.API.Package>(response);
                return apiPackage.Id;
            }
            catch (EslServerException e)
            {
                throw new EslServerException ("Could not create template." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException ("Could not create template." + " Exception: " + e.Message, e);
            }
        }

        internal Placeholder AddPlaceholder(PackageId templateId, Placeholder placeholder)
        {
            string path = urls.UrlFor(UrlTemplate.ROLE_PATH)
                .Replace("{packageId}", templateId.Id)
                    .Build();
            Role apiPayload = new Role();
            apiPayload.Id = placeholder.Id;
            apiPayload.Name = placeholder.Name;

            try
            {
                string json = JsonConvert.SerializeObject(apiPayload, settings);
                string response = restClient.Post(path, json);
                Silanis.ESL.API.Role apiRole = JsonConvert.DeserializeObject<Silanis.ESL.API.Role>(response);
                return new Placeholder(apiRole.Id);
            }
            catch (EslServerException e)
            {
                throw new EslServerException ("Could not add placeholder." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException ("Could not add placeholder." + " Exception: " + e.Message, e);
            }
        }
        
        internal Placeholder UpdatePlaceholder(PackageId templateId, Placeholder placeholder)
        {
            string path = urls.UrlFor(UrlTemplate.ROLE_ID_PATH)
                .Replace("{packageId}", templateId.Id)
                .Replace("{roleId}", placeholder.Id)
                .Build();
            Role apiPayload = new Role();
            apiPayload.Id = placeholder.Id;
            apiPayload.Name = placeholder.Name;

            try {
                string json = JsonConvert.SerializeObject(apiPayload, settings);
                string response = restClient.Put(path, json);
                Silanis.ESL.API.Role apiRole = JsonConvert.DeserializeObject<Silanis.ESL.API.Role>(response);
                return new Placeholder(apiRole.Id, apiRole.Name);
            }
            catch (EslServerException e)
            {
                throw new EslServerException ("Could not update the placeholder." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException ("Could not update the placeholder." + " Exception: " + e.Message, e);
            }
        }
        
        public void Update(Silanis.ESL.API.Package apiTemplate)
        {
            string path = urls.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", apiTemplate.Id)
                .Build();

            try
            {
                string json = JsonConvert.SerializeObject(apiTemplate, settings);
                restClient.Post(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException ("Could not update template." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException ("Could not update template." + " Exception: " + e.Message, e);
            }
        }
    }
}

