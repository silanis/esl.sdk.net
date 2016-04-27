using System;
using System.Collections.Generic;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class GetGroupSummariesExample : SdkSample
    {
        public List<GroupSummary> RetrievedGroupSummaries;
        public static void Main(string[] args)
        {
            new GetGroupSummariesExample().Run();
        }

        override public void Execute()
        {
            RetrievedGroupSummaries = eslClient.GroupService.GetGroupSummaries();

            foreach(var groupSummary in RetrievedGroupSummaries) {
                Console.WriteLine ("GroupSummary id : {0}, email : {1}, name : {2}", groupSummary.Id, groupSummary.Email, groupSummary.Name);
            }
            Console.WriteLine ("Total : {0}" + RetrievedGroupSummaries.Count);
        }
    }
}

