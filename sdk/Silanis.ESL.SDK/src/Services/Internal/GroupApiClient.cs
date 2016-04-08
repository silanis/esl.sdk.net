using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    internal class GroupApiClient
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;

        public GroupApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate (baseUrl);
            this.settings = settings;
        }
        
        public Silanis.ESL.API.Result<Silanis.ESL.API.Group> GetMyGroups() {
            var path = template.UrlFor (UrlTemplate.GROUPS_PATH)
                    .Build ();

            try {
                var response = restClient.Get(path);
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.Group>> (response, settings );
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve group list." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve group list." + " Exception: " + e.Message, e);
            }
        }
        
        public Silanis.ESL.API.Group GetGroup( string groupId ) {
            var path = template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace ("{groupId}", groupId)
                    .Build ();

            try {
                var response = restClient.Get(path);
                var apiGroup = JsonConvert.DeserializeObject<Silanis.ESL.API.Group> (response, settings);
                return apiGroup;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve group." + " Exception: " + e.Message, e);
            }
        }
        
        public Silanis.ESL.API.Group CreateGroup( Silanis.ESL.API.Group apiGroup ) {
            var path = template.UrlFor (UrlTemplate.GROUPS_PATH).Build ();
            try {
                var json = JsonConvert.SerializeObject (apiGroup, settings);
                var response = restClient.Post(path, json);              
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Group> (response);
                return apiResponse;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to create new group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to create new group." + " Exception: " + e.Message, e);
            }
        }

        public Silanis.ESL.API.Group UpdateGroup( Silanis.ESL.API.Group apiGroup, String groupId ) {
            var path = template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace("{groupId}", groupId)
                .Build ();
            try {
                var json = JsonConvert.SerializeObject (apiGroup, settings);
                var response = restClient.Put(path, json);              
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Group> (response);
                return apiResponse;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to update group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to update group." + " Exception: " + e.Message, e);
            }
        }
        
        public Silanis.ESL.API.GroupMember AddMember( string groupId, Silanis.ESL.API.GroupMember apiGroupMember ) {
            var path = template.UrlFor (UrlTemplate.GROUPS_MEMBER_PATH)
                .Replace("{groupId}", groupId )
                .Build ();
            try {
                var json = JsonConvert.SerializeObject (apiGroupMember, settings);
                var response = restClient.Post(path, json);              
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.GroupMember> (response);
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to add new member." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to add new member." + " Exception: " + e.Message, e);
            }
        }

        public Silanis.ESL.API.Group InviteMember( string groupId, Silanis.ESL.API.GroupMember apiGroupMember ) {
            var path = template.UrlFor (UrlTemplate.GROUPS_INVITE_PATH)
                .Replace("{groupId}", groupId )
                    .Build ();
            try {
                var json = JsonConvert.SerializeObject (apiGroupMember, settings);
                var response = restClient.Post(path, json);              
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Group> (response);
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
            var path = template.UrlFor (UrlTemplate.GROUPS_ID_PATH)
                .Replace ("{groupId}", groupId)
                .Build ();

            try {
                restClient.Delete(path);
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to delete group." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to delete group." + " Exception: " + e.Message, e);
            }
        }

        public Silanis.ESL.API.Result<Silanis.ESL.API.GroupSummary> GetGroupSummaries() {
            var path = template.UrlFor (UrlTemplate.GROUPS_SUMMARY_PATH)
                .Build ();

            try {
                var response = restClient.Get(path);
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.GroupSummary>> (response, settings );
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

