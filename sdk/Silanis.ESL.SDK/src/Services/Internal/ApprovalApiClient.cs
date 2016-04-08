using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class ApprovalApiClient
    {
        private UrlTemplate template;
        private RestClient restClient;
        private JsonSerializerSettings jsonSettings;

        public ApprovalApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings jsonSettings)
        {
            this.restClient = restClient;
            template = new UrlTemplate (baseUrl);
            this.jsonSettings = jsonSettings;
        }        
        
        public void DeleteApproval(string packageId, string documentId, string approvalId)
        {
            var path = template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approvalId)
                    .Build();
            try {
                restClient.Delete(path);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not delete signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not delete signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public string AddApproval(PackageId packageId, string documentId, Approval approval)
        {
            var path = template.UrlFor(UrlTemplate.APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Build();

            try {
                var json = JsonConvert.SerializeObject (approval, jsonSettings);
                var response = restClient.Post(path, json);
                var apiApproval = JsonConvert.DeserializeObject<Silanis.ESL.API.Approval> (response, jsonSettings);
                return apiApproval.Id;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not add signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not add signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public void ModifyApproval(PackageId packageId, string documentId, Approval approval)
        {
            var path = template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approval.Id)
                    .Build();

            try {
                var json = JsonConvert.SerializeObject (approval, jsonSettings);
                restClient.Put(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not modify signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not modify signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public void UpdateApprovals(PackageId packageId, string documentId, IList<Approval> approvalList)
        {
            var path = template.UrlFor(UrlTemplate.APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try {
                var json = JsonConvert.SerializeObject (approvalList, jsonSettings);
                restClient.Put(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not update signatures.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not update signatures.\t" + " Exception: " + e.Message, e);
            }
        }

        public Approval GetApproval(PackageId packageId, string documentId, string approvalId)
        {
            var path = template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approvalId)
                    .Build();

            try {
                var response = restClient.Get(path);
                var apiApproval = JsonConvert.DeserializeObject<Silanis.ESL.API.Approval> (response, jsonSettings);
                return apiApproval;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not get signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not get signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public string AddField(PackageId packageId, string documentId, SignatureId signatureId, Silanis.ESL.API.Field field)
        {
            var path = template.UrlFor(UrlTemplate.FIELD_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Build();

            try {
                var json = JsonConvert.SerializeObject (field, jsonSettings);
                var response = restClient.Post(path, json);
                var apiField = JsonConvert.DeserializeObject<Silanis.ESL.API.Field> (response, jsonSettings);
                return apiField.Id;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not add field to signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not add field to signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public void ModifyField(PackageId packageId, string documentId, SignatureId signatureId, Silanis.ESL.API.Field field)
        {
            var path = template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", field.Id)
                    .Build();

            try {
                var json = JsonConvert.SerializeObject (field, jsonSettings);
                restClient.Put(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not modify field from signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not modify field from signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public Silanis.ESL.API.Field GetField(PackageId packageId, string documentId, SignatureId signatureId, string fieldId)
        {
            var path = template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", fieldId)
                    .Build();

            try {
                var response = restClient.Get(path);
                var apiField = JsonConvert.DeserializeObject<Silanis.ESL.API.Field> (response, jsonSettings);
                return apiField;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not get field from signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not get field from signature.\t" + " Exception: " + e.Message, e);
            }

        }

        public void DeleteField(PackageId packageId, string documentId, SignatureId signatureId, string fieldId)
        {
            var path = template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", fieldId)
                    .Build();

            try {
                restClient.Delete(path);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not delete field from signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not delete field from signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public IList<Approval> GetAllSignableApprovals(PackageId packageId, string documentId, string signerId)
        {
            var path = template.UrlFor(UrlTemplate.SIGNABLE_APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{signerId}", signerId)
                    .Build();
            IList<Approval> response = null;

            try {
                var stringResponse = restClient.Get(path);
                response = JsonConvert.DeserializeObject<IList<Approval>>(stringResponse, jsonSettings);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not get all signable signatures.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not get all signable signatures.\t" + " Exception: " + e.Message, e);
            }

            return response;
        }
    }
}

