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
        
        internal string CreateTemplateFromPackage(string originalPackageId, Package delta)
        {
            delta.Type = "TEMPLATE";
            var path = urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", originalPackageId)
                .Build ();
            try {
                var deltaJson = JsonConvert.SerializeObject (delta, settings);
                var response = restClient.Post(path, deltaJson);              
                var apiResult = JsonConvert.DeserializeObject<Package> (response);
                return apiResult.Id;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create a template." + " Exception: " + e.Message, e.ServerError, e);
            } catch (Exception e) {
                throw new EslException ("Could not create a template." + " Exception: " + e.Message, e);
            }
        }
        
        internal string CreatePackageFromTemplate(string templateId, Package delta)
        {
            var path = urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", templateId)
                .Build ();
            try {
                var deltaJson = JsonConvert.SerializeObject (delta, settings);
                var response = restClient.Post(path, deltaJson);              
                var apiResult = JsonConvert.DeserializeObject<Package> (response);
                return apiResult.Id;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create a package from template." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Could not create a package from template." + " Exception: " + e.Message, e);
            }
        }
        
        internal string CreateTemplate(Package template)
        {
            var path = urls.UrlFor(UrlTemplate.PACKAGE_PATH).Build();

            try
            {
                var json = JsonConvert.SerializeObject(template, settings);
                var response = restClient.Post(path, json);
                var apiPackage = JsonConvert.DeserializeObject<Package>(response);
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
            var path = urls.UrlFor(UrlTemplate.ROLE_PATH)
                .Replace("{packageId}", templateId.Id)
                    .Build();
            var apiPayload = new Role();
            apiPayload.Id = placeholder.Id;
            apiPayload.Name = placeholder.Name;

            try
            {
                var json = JsonConvert.SerializeObject(apiPayload, settings);
                var response = restClient.Post(path, json);
                var apiRole = JsonConvert.DeserializeObject<Role>(response);
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
            var path = urls.UrlFor(UrlTemplate.ROLE_ID_PATH)
                .Replace("{packageId}", templateId.Id)
                .Replace("{roleId}", placeholder.Id)
                .Build();
            var apiPayload = new Role();
            apiPayload.Id = placeholder.Id;
            apiPayload.Name = placeholder.Name;

            try {
                var json = JsonConvert.SerializeObject(apiPayload, settings);
                var response = restClient.Put(path, json);
                var apiRole = JsonConvert.DeserializeObject<Role>(response);
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
        
        public void Update(Package apiTemplate)
        {
            var path = urls.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", apiTemplate.Id)
                .Build();

            try
            {
                var json = JsonConvert.SerializeObject(apiTemplate, settings);
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

