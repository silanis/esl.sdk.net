using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Services
{
    public class GroupService
    {
        private GroupApiClient apiClient;
        
        internal GroupService(GroupApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
    
        public List<Group> GetMyGroups() {
            Silanis.ESL.API.Result<Silanis.ESL.API.Group> apiResponse = apiClient.GetMyGroups();
            List<Group> result = new List<Group>();
			foreach ( Silanis.ESL.API.Group apiGroup in apiResponse.Results ) {
                result.Add( new GroupConverter( apiGroup ).ToSDKGroup() );
            }
            return result;
        }

        public Group GetGroup( GroupId groupId ) {
            Silanis.ESL.API.Group apiGroup = apiClient.GetGroup(groupId.Id);
            Group sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            return sdkGroup;
        }

        public Group CreateGroup( Group group ) {
			Silanis.ESL.API.Group apiGroup = new GroupConverter( group ).ToAPIGroupWithoutMembers();
            apiGroup = apiClient.CreateGroup( apiGroup );
            Group sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            foreach ( GroupMember groupMember in group.Members ) {
                AddMember( sdkGroup.Id, groupMember );
            }
            return sdkGroup;
        }

        public Group UpdateGroup( Group group, GroupId groupId ) {
            Silanis.ESL.API.Group apiGroup = new GroupConverter( group ).ToAPIGroup();
            apiGroup = apiClient.UpdateGroup( apiGroup, groupId.Id );
            Group sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            return sdkGroup;
        }

        public GroupMember AddMember( GroupId groupId, GroupMember groupMember ) {
            Silanis.ESL.API.GroupMember apiGroupMember = new GroupMemberConverter(groupMember).ToAPIGroupMember();
            Silanis.ESL.API.GroupMember apiResponse = apiClient.AddMember( groupId.Id, apiGroupMember );
            return new GroupMemberConverter( apiResponse ).ToSDKGroupMember();
        }

        public Group InviteMember( GroupId groupId, GroupMember groupMember ) {
            Silanis.ESL.API.GroupMember apiGroupMember = new GroupMemberConverter(groupMember).ToAPIGroupMember();
            Silanis.ESL.API.Group apiResponse = apiClient.InviteMember( groupId.Id, apiGroupMember );
            return new GroupConverter( apiResponse ).ToSDKGroup();
        }

        public void DeleteGroup( GroupId groupId ) {
            apiClient.DeleteGroup(groupId.Id);
        }

        public List<string> GetGroupMemberEmails( GroupId groupId ) {
            List<string> result = null;
            Group group = GetGroup(groupId);

            if (group != null)
            {
                result = new List<string>();

                foreach (GroupMember groupMember in group.Members)
                {
                    result.Add(groupMember.Email);
                }
            }

            return result;
        }

        public List<GroupMember> GetGroupMembers( GroupId groupId ) {
            List<GroupMember> result = null;

            Group group = GetGroup(groupId);
            if (group != null)
            {
                result = group.Members;
            }
            return result;
        }

        public List<GroupSummary> GetGroupSummaries() {
            Silanis.ESL.API.Result<Silanis.ESL.API.GroupSummary> apiResponse = apiClient.GetGroupSummaries();
            List<GroupSummary> result = new List<GroupSummary>();
            foreach ( Silanis.ESL.API.GroupSummary apiGroupSummary in apiResponse.Results ) {
                result.Add( new GroupSummaryConverter( apiGroupSummary ).ToSDKGroupSummary() );
            }
            return result;
        }
    }
}

