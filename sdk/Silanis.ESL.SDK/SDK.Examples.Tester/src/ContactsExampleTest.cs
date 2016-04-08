using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ContactsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ContactsExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;
            var signer = documentPackage.GetSigner(example.email1);

            // Assert signer information is correct
            Assert.AreEqual(signer.Email, example.signerForPackage.Email);
            Assert.AreEqual(signer.FirstName, example.signerForPackage.FirstName);
            Assert.AreEqual(signer.LastName, example.signerForPackage.LastName);
            Assert.AreEqual(signer.Title, example.signerForPackage.Title);
            Assert.AreEqual(signer.Company, example.signerForPackage.Company);

            // Assert new signer is added to the contacts
            Assert.IsNotNull(example.afterContacts[example.email2]);
            Assert.AreEqual(example.afterContacts[example.email2].FirstName, "John");
            Assert.AreEqual(example.afterContacts[example.email2].LastName, "Smith");
        }
    }
}

