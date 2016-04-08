using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class GettingStartedExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GettingStartedExample();
            example.Run();

        }
    }
}

