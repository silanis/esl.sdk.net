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
            var apiResponse = apiClient.GetMyGroups();
            var result = new List<Group>();
			foreach ( var apiGroup in apiResponse.Results ) {
                result.Add( new GroupConverter( apiGroup ).ToSDKGroup() );
            }
            return result;
        }

        public Group GetGroup( GroupId groupId ) {
            var apiGroup = apiClient.GetGroup(groupId.Id);
            var sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            return sdkGroup;
        }

        public Group CreateGroup( Group group ) {
			var apiGroup = new GroupConverter( group ).ToAPIGroupWithoutMembers();
            apiGroup = apiClient.CreateGroup( apiGroup );
            var sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            foreach ( var groupMember in group.Members ) {
                AddMember( sdkGroup.Id, groupMember );
            }
            return sdkGroup;
        }

        public Group UpdateGroup( Group group, GroupId groupId ) {
            var apiGroup = new GroupConverter( group ).ToAPIGroup();
            apiGroup = apiClient.UpdateGroup( apiGroup, groupId.Id );
            var sdkGroup = new GroupConverter( apiGroup ).ToSDKGroup();
            return sdkGroup;
        }

        public GroupMember AddMember( GroupId groupId, GroupMember groupMember ) {
            var apiGroupMember = new GroupMemberConverter(groupMember).ToAPIGroupMember();
            var apiResponse = apiClient.AddMember( groupId.Id, apiGroupMember );
            return new GroupMemberConverter( apiResponse ).ToSDKGroupMember();
        }

        public Group InviteMember( GroupId groupId, GroupMember groupMember ) {
            var apiGroupMember = new GroupMemberConverter(groupMember).ToAPIGroupMember();
            var apiResponse = apiClient.InviteMember( groupId.Id, apiGroupMember );
            return new GroupConverter( apiResponse ).ToSDKGroup();
        }

        public void DeleteGroup( GroupId groupId ) {
            apiClient.DeleteGroup(groupId.Id);
        }

        public List<string> GetGroupMemberEmails( GroupId groupId ) {
            List<string> result = null;
            var group = GetGroup(groupId);

            if (group != null)
            {
                result = new List<string>();

                foreach (var groupMember in group.Members)
                {
                    result.Add(groupMember.Email);
                }
            }

            return result;
        }

        public List<GroupMember> GetGroupMembers( GroupId groupId ) {
            List<GroupMember> result = null;

            var group = GetGroup(groupId);
            if (group != null)
            {
                result = group.Members;
            }
            return result;
        }

        public List<GroupSummary> GetGroupSummaries() {
            var apiResponse = apiClient.GetGroupSummaries();
            var result = new List<GroupSummary>();
            foreach ( var apiGroupSummary in apiResponse.Results ) {
                result.Add( new GroupSummaryConverter( apiGroupSummary ).ToSDKGroupSummary() );
            }
            return result;
        }
    }
}

