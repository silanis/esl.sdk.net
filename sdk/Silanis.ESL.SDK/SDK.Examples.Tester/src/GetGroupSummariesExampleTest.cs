using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class GetGroupSummariesExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GetGroupSummariesExample();
            example.Run();

            Assert.IsNotNull(example.RetrievedGroupSummaries);
            Assert.IsTrue(example.RetrievedGroupSummaries.Count >= 0);
        }
    }
}

