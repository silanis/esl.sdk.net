using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    internal class GroupApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        public GroupApiClient(RestClient restClient, string baseUrl)
        {
            _restClient = restClient;
            _template = new UrlTemplate (baseUrl);
        }
        
        public Result<API.Group> GetMyGroups() {
            var path = _template.UrlFor (UrlTemplate.GROUPS_PATH)
                    .Build ();

            try {
                var response = _restClient.Get(path);
                var apiResponse = Json.DeserializeWithSettings<Result<API.Group>> (response );
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve group list." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve group list." + " Exception: " + e.Message, e);
            }
        }
        
        public API.Group GetGroup( string groupId ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace ("{groupId}", groupId)
                    .Build ();

            try {
                var response = _restClient.Get(path);
                var apiGroup = Json.DeserializeWithSettings<API.Group> (response);
                return apiGroup;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve group." + " Exception: " + e.Message, e);
            }
        }
        
        public API.Group CreateGroup( API.Group apiGroup ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_PATH).Build ();
            try {
                var json = Json.SerializeWithSettings (apiGroup);
                var response = _restClient.Post(path, json);              
                var apiResponse = Json.Deserialize<API.Group> (response);
                return apiResponse;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to create new group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to create new group." + " Exception: " + e.Message, e);
            }
        }

        public API.Group UpdateGroup( API.Group apiGroup, String groupId ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace("{groupId}", groupId)
                .Build ();
            try {
                var json = Json.SerializeWithSettings (apiGroup);
                var response = _restClient.Put(path, json);              
                var apiResponse = Json.Deserialize<API.Group> (response);
                return apiResponse;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to update group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to update group." + " Exception: " + e.Message, e);
            }
        }
        
        public API.GroupMember AddMember( string groupId, API.GroupMember apiGroupMember ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_MEMBER_PATH)
                .Replace("{groupId}", groupId )
                .Build ();
            try {
                var json = Json.SerializeWithSettings (apiGroupMember);
                var response = _restClient.Post(path, json);              
                var apiResponse = Json.Deserialize<API.GroupMember> (response);
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to add new member." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to add new member." + " Exception: " + e.Message, e);
            }
        }

        public API.Group InviteMember( string groupId, API.GroupMember apiGroupMember ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_INVITE_PATH)
                .Replace("{groupId}", groupId )
                    .Build ();
            try {
                var json = Json.SerializeWithSettings (apiGroupMember);
                var response = _restClient.Post(path, json);              
                var apiResponse = Json.Deserialize<API.Group> (response);
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to invite member." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to invite member." + " Exception: " + e.Message, e);
            }
        }
        
        public void DeleteGroup( string groupId ) {
            var path = _template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace ("{groupId}", groupId)
                .Build ();

            try {
                _restClient.Delete(path);
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to delete group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to delete group." + " Exception: " + e.Message, e);
            }
        }

        public Result<API.GroupSummary> GetGroupSummaries() {
            var path = _template.UrlFor (UrlTemplate.GROUPS_SUMMARY_PATH)
                .Build ();

            try {
                var response = _restClient.Get(path);
                var apiResponse = Json.DeserializeWithSettings<Result<API.GroupSummary>> (response);
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve Group Summary list." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve Group Summary list." + " Exception: " + e.Message, e);
            }
        }
    }
}

