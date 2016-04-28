
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CustomSenderInfoInCreateNewTemplateExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CustomSenderInfoInCreateNewTemplateExample();
            example.Run();
            
            var template = example.EslClient.GetPackage( example.TemplateId );
            
            Assert.IsNotNull(template.SenderInfo);
        }
    }
}

