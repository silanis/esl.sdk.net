namespace Silanis.ESL.SDK
{
    internal class GroupSummaryConverter
    {
        private API.GroupSummary apiGroupSummary;
        private GroupSummary sdkGroupSummary;

        public GroupSummaryConverter( GroupSummary sdkGroupSummary ) {
            this.sdkGroupSummary = sdkGroupSummary;
            apiGroupSummary = null;
        }

        public GroupSummaryConverter( API.GroupSummary apiGroupSummary ) {
            this.apiGroupSummary = apiGroupSummary;
            sdkGroupSummary = null;
        }
        
        public API.GroupSummary ToAPIGroupSummary()
        {
            if (sdkGroupSummary == null)
            {
                return apiGroupSummary;
            }
            var result = new API.GroupSummary();

            result.Data = sdkGroupSummary.Data;
            result.Email = sdkGroupSummary.Email;
            result.Id = sdkGroupSummary.Id;
            result.Name = sdkGroupSummary.Name;

            return result;
        }

        public GroupSummary ToSDKGroupSummary()
        {
            if (apiGroupSummary == null)
            {
                return sdkGroupSummary;
            }

            return GroupSummaryBuilder.NewGroupSummary(apiGroupSummary.Email)
                    .WithId(apiGroupSummary.Id)
                    .WithName(apiGroupSummary.Name)
                    .WithData(apiGroupSummary.Data)
                    .Build();
        }
    }
}

