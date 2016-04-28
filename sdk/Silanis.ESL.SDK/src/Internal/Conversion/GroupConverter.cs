namespace Silanis.ESL.SDK
{
    internal class GroupConverter
    {
        private Group sdkGroup;
        private API.Group apiGroup;

        public GroupConverter( Group group )
        {
            sdkGroup = group;
            apiGroup = null;
        }

        public GroupConverter( API.Group apiGroup ) 
        {
            this.apiGroup = apiGroup;
            sdkGroup = null;
        }

        public API.Group ToAPIGroupWithoutMembers() {
            if (apiGroup != null)
            {
                return apiGroup;
            }
            else
            {
                var result = new API.Group();
                result.Name = sdkGroup.Name;
                result.Created = sdkGroup.Created;
                result.Updated = sdkGroup.Updated;
				if (sdkGroup.Id != null)
				{
					result.Id = sdkGroup.Id.Id;
				}
                result.Email = sdkGroup.Email;
                result.EmailMembers = sdkGroup.EmailMembers;
                return result;
            }
        }

        public API.Group ToAPIGroup() {

            if (apiGroup != null)
            {
                return apiGroup;
            }
            else
            {
                var result = ToAPIGroupWithoutMembers();

                foreach( var sdkMember in sdkGroup.Members ) {
                    result.AddMember(new GroupMemberConverter(sdkMember).ToAPIGroupMember());
                }
                return result;
            }

        }

        public Group ToSDKGroup()
        {
            if (sdkGroup != null)
            {
                return sdkGroup;
            }
            else
            {
                var builder = GroupBuilder.NewGroup(apiGroup.Name)
                    .WithEmail(apiGroup.Email);

                if (apiGroup.EmailMembers.HasValue)
                {
                    if (apiGroup.EmailMembers.Value)
                        builder.WithIndividualMemberEmailing();
                    else
                        builder.WithoutIndividualMemberEmailing();
                }

                if (apiGroup.Id != null)
                {
                    builder.WithId(new GroupId(apiGroup.Id));
                }

                foreach (var apiGroupMember in apiGroup.Members)
                {
                    var sdkGroupMember = new GroupMemberConverter(apiGroupMember).ToSDKGroupMember();
                    builder.WithMember(sdkGroupMember);
                }

                return builder.Build();
            }
        }
    }
}

