using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CustomSenderInfoInCreatePackageFromTemplateExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CustomSenderInfoInCreatePackageFromTemplateExample();
            example.Run();
            
            var template = example.EslClient.GetPackage( example.TemplateId );
            var package = example.RetrievedPackage;
            
            Assert.IsNotNull(template.SenderInfo);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_FIRST_NAME, package.SenderInfo.FirstName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_SECOND_NAME, package.SenderInfo.LastName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_COMPANY, package.SenderInfo.Company);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_TITLE, package.SenderInfo.Title);
        }
    }
}

