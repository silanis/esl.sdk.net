using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreateTemplateOnBehalfOfAnotherSenderExampleTest
    {
        private CreateTemplateOnBehalfOfAnotherSenderExample example;

        [Test()]
        public void VerifyResult()
        {
            example = new CreateTemplateOnBehalfOfAnotherSenderExample();
            example.Run();

            // Verify the template has the correct sender
            DocumentPackage retrievedTemplate = example.EslClient.GetPackage(example.templateId);
            verifySenderInfo(retrievedTemplate);

            // Verify the package created from template has the correct sender
            DocumentPackage retrievedPackage = example.RetrievedPackage;
            verifySenderInfo(retrievedPackage);
        }

        private void verifySenderInfo(DocumentPackage documentPackage) {
            SenderInfo senderInfo = documentPackage.SenderInfo;
            Assert.AreEqual(example.SENDER_FIRST_NAME, senderInfo.FirstName);
            Assert.AreEqual(example.SENDER_LAST_NAME, senderInfo.LastName);
            Assert.AreEqual(example.SENDER_TITLE, senderInfo.Title);
            Assert.AreEqual(example.SENDER_COMPANY, senderInfo.Company);

            Signer sender = documentPackage.GetSigner(example.senderEmail);
            Assert.AreEqual(example.SENDER_FIRST_NAME, sender.FirstName);
            Assert.AreEqual(example.SENDER_LAST_NAME, sender.LastName);
            Assert.AreEqual(example.senderEmail, sender.Email);
            Assert.AreEqual(example.SENDER_TITLE, sender.Title);
            Assert.AreEqual(example.SENDER_COMPANY, sender.Company);
        }
    }
}

