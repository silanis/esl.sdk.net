using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CustomSenderInfoInCreatePackageFromTemplateExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CustomSenderInfoInCreatePackageFromTemplateExample example = new CustomSenderInfoInCreatePackageFromTemplateExample();
            example.Run();
            
            DocumentPackage template = example.EslClient.GetPackage( example.TemplateId );
            DocumentPackage package = example.RetrievedPackage;
            
            Assert.IsNotNull(template.SenderInfo);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_FIRST_NAME, package.SenderInfo.FirstName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_SECOND_NAME, package.SenderInfo.LastName);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_COMPANY, package.SenderInfo.Company);
            Assert.AreEqual(CustomSenderInfoInCreatePackageFromTemplateExample.SENDER_TITLE, package.SenderInfo.Title);
        }
    }
}

