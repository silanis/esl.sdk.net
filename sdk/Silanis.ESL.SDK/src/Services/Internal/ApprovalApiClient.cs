using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class ApprovalApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;
        private readonly Json _json;

        [Obsolete("Please Use EslClient")]
        public ApprovalApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            _json = new Json(jsonSerializerSettings);
            _restClient = restClient;
            _template = new UrlTemplate (baseUrl);
        } 
        internal ApprovalApiClient(RestClient restClient, string baseUrl)
        {
            _json = new Json();
            _restClient = restClient;
            _template = new UrlTemplate (baseUrl);
        }        
        
        public void DeleteApproval(string packageId, string documentId, string approvalId)
        {
            var path = _template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approvalId)
                    .Build();
            try {
                _restClient.Delete(path);
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
            var path = _template.UrlFor(UrlTemplate.APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Build();

            try {
                var json = _json.SerializeWithSettings (approval);
                var response = _restClient.Post(path, json);
                var apiApproval = _json.DeserializeWithSettings<Approval> (response);
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
            var path = _template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approval.Id)
                    .Build();

            try {
                var json = _json.SerializeWithSettings (approval);
                _restClient.Put(path, json);
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
            var path = _template.UrlFor(UrlTemplate.APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try {
                var json = _json.SerializeWithSettings (approvalList);
                _restClient.Put(path, json);
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
            var path = _template.UrlFor(UrlTemplate.APPROVAL_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", approvalId)
                    .Build();

            try {
                var response = _restClient.Get(path);
                var apiApproval = _json.DeserializeWithSettings<Approval> (response);
                return apiApproval;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not get signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not get signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public string AddField(PackageId packageId, string documentId, SignatureId signatureId, API.Field field)
        {
            var path = _template.UrlFor(UrlTemplate.FIELD_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Build();

            try {
                var json = _json.SerializeWithSettings (field);
                var response = _restClient.Post(path, json);
                var apiField = _json.DeserializeWithSettings<API.Field> (response);
                return apiField.Id;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not add field to signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not add field to signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public void ModifyField(PackageId packageId, string documentId, SignatureId signatureId, API.Field field)
        {
            var path = _template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", field.Id)
                    .Build();

            try {
                var json = _json.SerializeWithSettings (field);
                _restClient.Put(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not modify field from signature.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not modify field from signature.\t" + " Exception: " + e.Message, e);
            }
        }

        public API.Field GetField(PackageId packageId, string documentId, SignatureId signatureId, string fieldId)
        {
            var path = _template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", fieldId)
                    .Build();

            try {
                var response = _restClient.Get(path);
                var apiField = _json.DeserializeWithSettings<API.Field> (response);
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
            var path = _template.UrlFor(UrlTemplate.FIELD_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{approvalId}", signatureId.Id)
                    .Replace("{fieldId}", fieldId)
                    .Build();

            try {
                _restClient.Delete(path);
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
            var path = _template.UrlFor(UrlTemplate.SIGNABLE_APPROVAL_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{documentId}", documentId)
                    .Replace("{signerId}", signerId)
                    .Build();
            IList<Approval> response;

            try {
                var stringResponse = _restClient.Get(path);
                response = _json.DeserializeWithSettings<IList<Approval>>(stringResponse);
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

