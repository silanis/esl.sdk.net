using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class GetGroupSummariesExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            GetGroupSummariesExample example = new GetGroupSummariesExample();
            example.Run();

            Assert.IsNotNull(example.retrievedGroupSummaries);
            Assert.GreaterOrEqual(example.retrievedGroupSummaries.Count, 0);
        }
    }
}

