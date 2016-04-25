using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class TemplateExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            TemplateExample example = new TemplateExample(  );
            example.Run();

            DocumentPackage template = example.EslClient.GetPackage(example.templateId);

            Assert.AreEqual(example.UPDATED_TEMPLATE_NAME, template.Name);
            Assert.AreEqual(example.UPDATED_TEMPLATE_DESCRIPTION, template.Description);

            DocumentPackage documentPackage = example.EslClient.GetPackage(example.instantiatedTemplateId);

            Assert.AreEqual(example.PACKAGE_NAME, documentPackage.Name);

            Assert.AreEqual(example.SIGNER1_FIRST_NAME, documentPackage.GetSigner(example.email1).FirstName);
            Assert.AreEqual(example.SIGNER1_LAST_NAME, documentPackage.GetSigner(example.email1).LastName);
            Assert.AreEqual(example.SIGNER1_TITLE, documentPackage.GetSigner(example.email1).Title);
            Assert.AreEqual(example.SIGNER1_COMPANY, documentPackage.GetSigner(example.email1).Company);

            Assert.AreEqual(example.SIGNER2_FIRST_NAME, documentPackage.GetSigner(example.email2).FirstName);
            Assert.AreEqual(example.SIGNER2_LAST_NAME, documentPackage.GetSigner(example.email2).LastName);
            Assert.AreEqual(example.SIGNER2_TITLE, documentPackage.GetSigner(example.email2).Title);
            Assert.AreEqual(example.SIGNER2_COMPANY, documentPackage.GetSigner(example.email2).Company);
        }
    }
}

