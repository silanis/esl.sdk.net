using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class CreateTemplateOnBehalfOfAnotherSenderExampleTest
    {
        private CreateTemplateOnBehalfOfAnotherSenderExample example;

        [TestMethod]
        public void VerifyResult()
        {
            example = new CreateTemplateOnBehalfOfAnotherSenderExample();
            example.Run();

            // Verify the template has the correct sender
            var retrievedTemplate = example.EslClient.GetPackage(example.templateId);
            verifySenderInfo(retrievedTemplate);

            // Verify the package created from template has the correct sender
            var retrievedPackage = example.RetrievedPackage;
            verifySenderInfo(retrievedPackage);
        }

        private void verifySenderInfo(DocumentPackage documentPackage) {
            var senderInfo = documentPackage.SenderInfo;
            Assert.AreEqual(example.SENDER_FIRST_NAME, senderInfo.FirstName);
            Assert.AreEqual(example.SENDER_LAST_NAME, senderInfo.LastName);
            Assert.AreEqual(example.SENDER_TITLE, senderInfo.Title);
            Assert.AreEqual(example.SENDER_COMPANY, senderInfo.Company);

            var sender = documentPackage.GetSigner(example.senderEmail);
            Assert.AreEqual(example.SENDER_FIRST_NAME, sender.FirstName);
            Assert.AreEqual(example.SENDER_LAST_NAME, sender.LastName);
            Assert.AreEqual(example.senderEmail, sender.Email);
            Assert.AreEqual(example.SENDER_TITLE, sender.Title);
            Assert.AreEqual(example.SENDER_COMPANY, sender.Company);
        }
    }
}

