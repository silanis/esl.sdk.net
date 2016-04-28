using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class TemplateApiClient
    {
        private readonly UrlTemplate _urls;
        private readonly RestClient _restClient;
        private readonly Json _json;
        
        internal TemplateApiClient(RestClient restClient, string baseUrl)
        {
            _json = new Json();
            _restClient = restClient;
            _urls = new UrlTemplate (baseUrl);
        }
        
        internal string CreateTemplateFromPackage(string originalPackageId, Package delta)
        {
            delta.Type = "TEMPLATE";
            var path = _urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", originalPackageId)
                .Build ();
            try {
                var deltaJson = _json.SerializeWithSettings (delta);
                var response = _restClient.Post(path, deltaJson);              
                var apiResult = _json.Deserialize<Package> (response);
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
            var path = _urls.UrlFor (UrlTemplate.CLONE_PACKAGE_PATH).Replace("{packageId}", templateId)
                .Build ();
            try {
                var deltaJson = _json.SerializeWithSettings (delta);
                var response = _restClient.Post(path, deltaJson);              
                var apiResult = _json.Deserialize<Package> (response);
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
            var path = _urls.UrlFor(UrlTemplate.PACKAGE_PATH).Build();

            try
            {
                var json = _json.SerializeWithSettings(template);
                var response = _restClient.Post(path, json);
                var apiPackage = _json.Deserialize<Package>(response);
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
            var path = _urls.UrlFor(UrlTemplate.ROLE_PATH)
                .Replace("{packageId}", templateId.Id)
                    .Build();
            var apiPayload = new Role();
            apiPayload.Id = placeholder.Id;
            apiPayload.Name = placeholder.Name;

            try
            {
                var json = _json.SerializeWithSettings(apiPayload);
                var response = _restClient.Post(path, json);
                var apiRole = _json.Deserialize<Role>(response);
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
            var path = _urls.UrlFor(UrlTemplate.ROLE_ID_PATH)
                .Replace("{packageId}", templateId.Id)
                .Replace("{roleId}", placeholder.Id)
                .Build();
            var apiPayload = new Role {Id = placeholder.Id, Name = placeholder.Name};

            try {
                var json = _json.SerializeWithSettings(apiPayload);
                var response = _restClient.Put(path, json);
                var apiRole = _json.Deserialize<Role>(response);
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
            var path = _urls.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", apiTemplate.Id)
                .Build();

            try
            {
                var json = _json.SerializeWithSettings(apiTemplate);
                _restClient.Post(path, json);
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

