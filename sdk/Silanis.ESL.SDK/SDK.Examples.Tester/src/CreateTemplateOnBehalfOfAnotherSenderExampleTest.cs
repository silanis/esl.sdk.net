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
            var retrievedTemplate = example.EslClient.GetPackage(example.TemplateId);
            verifySenderInfo(retrievedTemplate);

            // Verify the package created from template has the correct sender
            var retrievedPackage = example.RetrievedPackage;
            verifySenderInfo(retrievedPackage);
        }

        private void verifySenderInfo(DocumentPackage documentPackage) {
            var senderInfo = documentPackage.SenderInfo;
            Assert.AreEqual(example.SenderFirstName, senderInfo.FirstName);
            Assert.AreEqual(example.SenderLastName, senderInfo.LastName);
            Assert.AreEqual(example.SenderTitle, senderInfo.Title);
            Assert.AreEqual(example.SenderCompany, senderInfo.Company);

            var sender = documentPackage.GetSigner(example.senderEmail);
            Assert.AreEqual(example.SenderFirstName, sender.FirstName);
            Assert.AreEqual(example.SenderLastName, sender.LastName);
            Assert.AreEqual(example.senderEmail, sender.Email);
            Assert.AreEqual(example.SenderTitle, sender.Title);
            Assert.AreEqual(example.SenderCompany, sender.Company);
        }
    }
}

