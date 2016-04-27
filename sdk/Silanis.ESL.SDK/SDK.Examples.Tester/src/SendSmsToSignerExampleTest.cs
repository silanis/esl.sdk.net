using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SendSmsToSignerExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SendSmsToSignerExample();
            example.Run();
        }
    }
}

