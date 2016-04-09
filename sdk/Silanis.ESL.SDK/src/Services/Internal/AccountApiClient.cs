using System;
using System.Globalization;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class AccountApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;
        
        public AccountApiClient(RestClient restClient, string apiUrl)
        {
            _restClient = restClient;
            _template = new UrlTemplate (apiUrl);            
        }
        
        public API.Sender InviteUser( API.Sender invitee ) {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_PATH).Build ();
            try {
                var json = Json.SerializeWithSettings (invitee);
                var response = _restClient.Post(path, json);
                var apiResponse = Json.DeserializeWithSettings<API.Sender> (response );
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to invite new account member.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to invite new account member.\t" + " Exception: " + e.Message, e);
            }
        }

        public void SendInvite( string senderId ) {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_INVITE_PATH)
                .Replace("{senderUid}", senderId)
                .Build ();
            try {
                _restClient.Post(path, null);
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to send invite to sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to send invite to sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public void UpdateSender(API.Sender apiSender, string senderId){
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_ID_PATH)
                .Replace("{senderUid}", senderId)
                .Build();
            try {
                var json = Json.SerializeWithSettings (apiSender);
                apiSender.Id = senderId;
                _restClient.Post(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not update sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not update sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public void DeleteSender(string senderId){
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_ID_PATH)
                .Replace("{senderUid}", senderId)
                .Build();
            try {
                _restClient.Delete(path);
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not delete sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not delete sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public Result<API.Sender> GetSenders(Direction direction, PageRequest request) {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_LIST_PATH)
                .Replace("{dir}", DirectionUtility.getDirection(direction))
                .Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
                .Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
                .Build();
            try {
                var response = _restClient.Get(path);
                var apiResponse = 
                    Json.DeserializeWithSettings<Result<API.Sender>> (response );
               
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException("Failed to retrieve Account Members List.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to retrieve Account Members List.\t" + " Exception: " + e.Message, e);
            }
        }

        public API.Sender GetSender(string senderId) {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_MEMBER_ID_PATH)
                .Replace("{senderUid}", senderId)
                .Build();
            try {
                var response = _restClient.Get(path);
                var apiResponse = Json.DeserializeWithSettings<API.Sender> (response );

                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException("Failed to retrieve Sender from Account.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to retrieve Sender from Account.\t" + " Exception: " + e.Message, e);
            }
        }

        public IList<API.DelegationUser> GetDelegates(string senderId) {
            var path = _template.UrlFor(UrlTemplate.DELEGATES_PATH)
                .Replace("{senderId}", senderId)
                .Build();

            try {
                var stringResponse = _restClient.Get(path);
                return Json.DeserializeWithSettings<IList<API.DelegationUser>>(stringResponse);
            }
            catch (EslServerException e) {
                    throw new EslServerException("Failed to retrieve delegate users from Sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                    throw new EslException("Failed to retrieve delegate users from Sender.\t" + " Exception: " + e.Message, e);
            }

        }

        public void UpdateDelegates(string senderId, List<string> delegateIds) {
            var path = _template.UrlFor(UrlTemplate.DELEGATES_PATH)
                .Replace("{senderId}", senderId)
                .Build();

            try {
                var json = Json.SerializeWithSettings(delegateIds);
                _restClient.Put(path, json);
            }

            catch (EslServerException e) {
                throw new EslServerException("Failed to update delegates of the Sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to update delegates of the Sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public void AddDelegate(string senderId, API.DelegationUser delegationUser) {
            var path = _template.UrlFor(UrlTemplate.DELEGATE_ID_PATH)
                .Replace("{senderId}", senderId)
                .Replace("{delegateId}", delegationUser.Id)
                .Build();
            try {
                var json = Json.SerializeWithSettings(delegationUser);
                _restClient.Post(path, json);
            }
            catch (EslServerException e) {
                throw new EslServerException("Failed to add delegate into the sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to add delegate into the sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public void RemoveDelegate(string senderId, string delegateId) {
            var path = _template.UrlFor(UrlTemplate.DELEGATE_ID_PATH)
                .Replace("{senderId}", senderId)
                .Replace("{delegateId}", delegateId)
                .Build();
            try {
                _restClient.Delete(path);
            }
            catch (EslServerException e) {
                throw new EslServerException("Failed to remove delegate from the sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to remove delegate from the sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public void ClearDelegates(string senderId) {
            var path = _template.UrlFor(UrlTemplate.DELEGATES_PATH)
                .Replace("{senderId}", senderId)
                .Build();
            try {
                _restClient.Delete(path);
            } 
            catch (EslServerException e) {
                throw new EslServerException("Failed to clear all delegates from the sender.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to clear all delegates from the sender.\t" + " Exception: " + e.Message, e);
            }
        }

        public IList<API.Sender> GetContacts() {
            var path = _template.UrlFor(UrlTemplate.ACCOUNT_CONTACTS_PATH)
                .Build();
            try {
                var response = _restClient.Get(path);
                return Json.DeserializeWithSettings<IList<API.Sender>> (response);
            }
            catch (EslServerException e) {
                throw new EslServerException("Failed to retrieve contacts.\t" + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Failed to retrieve contacts.\t" + " Exception: " + e.Message, e);
            }
        }
    }
}

