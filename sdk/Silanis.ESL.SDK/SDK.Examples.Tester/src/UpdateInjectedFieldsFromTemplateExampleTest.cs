using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class UpdateInjectedFieldsFromTemplateExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new UpdateInjectedFieldsFromTemplateExample();
            example.Run();
        }
    }
}

