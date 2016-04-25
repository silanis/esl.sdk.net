using System;

namespace Silanis.ESL.SDK
{
    internal class GroupSummaryConverter
    {
        private Silanis.ESL.API.GroupSummary apiGroupSummary;
        private GroupSummary sdkGroupSummary;

        public GroupSummaryConverter( GroupSummary sdkGroupSummary ) {
            this.sdkGroupSummary = sdkGroupSummary;
            this.apiGroupSummary = null;
        }

        public GroupSummaryConverter( Silanis.ESL.API.GroupSummary apiGroupSummary ) {
            this.apiGroupSummary = apiGroupSummary;
            this.sdkGroupSummary = null;
        }
        
        public Silanis.ESL.API.GroupSummary ToAPIGroupSummary()
        {
            if (sdkGroupSummary == null)
            {
                return apiGroupSummary;
            }
            Silanis.ESL.API.GroupSummary result = new Silanis.ESL.API.GroupSummary();

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

