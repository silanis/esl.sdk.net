using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class StampFieldValueExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new StampFieldValueExample();
            example.Run();

        }
    }
}

