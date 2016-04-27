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
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SenderFirstName, package.SenderInfo.FirstName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SenderSecondName, package.SenderInfo.LastName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SenderCompany, package.SenderInfo.Company);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SenderTitle, package.SenderInfo.Title);
        }
    }
}

