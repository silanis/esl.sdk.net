using System;

namespace Silanis.ESL.SDK
{
    internal class GroupMemberConverter
    {
        private Silanis.ESL.API.GroupMember apiMember;
        private GroupMember sdkMember;

        public GroupMemberConverter( GroupMember sdkMember ) {
            this.sdkMember = sdkMember;
            this.apiMember = null;
        }

        public GroupMemberConverter( Silanis.ESL.API.GroupMember apiMember ) {
            this.apiMember = apiMember;
            this.sdkMember = null;
        }

        public GroupMember ToSDKGroupMember() {
            if (sdkMember != null)
            {
                return sdkMember;
            }
            else
            {
                GroupMember result = new GroupMember();
                result.Email = apiMember.Email;
                result.FirstName = apiMember.FirstName;
                result.LastName = apiMember.LastName;
                result.GroupMemberType = new GroupMemberTypeConverter(apiMember.MemberType).ToSDKGroupMemberType();

                return result;
            }
        }

        public Silanis.ESL.API.GroupMember ToAPIGroupMember() {
            if (apiMember != null)
            {
                return apiMember;
            }
            else
            {
                Silanis.ESL.API.GroupMember result = new Silanis.ESL.API.GroupMember();

                result.Email = sdkMember.Email;
                result.FirstName = sdkMember.FirstName;
                result.LastName = sdkMember.LastName;
                result.MemberType = new GroupMemberTypeConverter(sdkMember.GroupMemberType).ToAPIMemberType();

                return result;
            }
        }
    }
}

