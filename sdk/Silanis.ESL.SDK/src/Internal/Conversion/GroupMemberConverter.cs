namespace Silanis.ESL.SDK
{
    internal class GroupMemberConverter
    {
        private API.GroupMember apiMember;
        private GroupMember sdkMember;

        public GroupMemberConverter( GroupMember sdkMember ) {
            this.sdkMember = sdkMember;
            apiMember = null;
        }

        public GroupMemberConverter( API.GroupMember apiMember ) {
            this.apiMember = apiMember;
            sdkMember = null;
        }

        public GroupMember ToSDKGroupMember() {
            if (sdkMember != null)
            {
                return sdkMember;
            }
            else
            {
                var result = new GroupMember();
                result.Email = apiMember.Email;
                result.FirstName = apiMember.FirstName;
                result.LastName = apiMember.LastName;
                result.GroupMemberType = new GroupMemberTypeConverter(apiMember.MemberType).ToSDKGroupMemberType();

                return result;
            }
        }

        public API.GroupMember ToAPIGroupMember() {
            if (apiMember != null)
            {
                return apiMember;
            }
            else
            {
                var result = new API.GroupMember();

                result.Email = sdkMember.Email;
                result.FirstName = sdkMember.FirstName;
                result.LastName = sdkMember.LastName;
                result.MemberType = new GroupMemberTypeConverter(sdkMember.GroupMemberType).ToAPIMemberType();

                return result;
            }
        }
    }
}

