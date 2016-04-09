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
            Assert.AreEqual(signer.Email, example.SignerForPackage.Email);
            Assert.AreEqual(signer.FirstName, example.SignerForPackage.FirstName);
            Assert.AreEqual(signer.LastName, example.SignerForPackage.LastName);
            Assert.AreEqual(signer.Title, example.SignerForPackage.Title);
            Assert.AreEqual(signer.Company, example.SignerForPackage.Company);

            // Assert new signer is added to the contacts
            Assert.IsNotNull(example.AfterContacts[example.email2]);
            Assert.AreEqual(example.AfterContacts[example.email2].FirstName, "John");
            Assert.AreEqual(example.AfterContacts[example.email2].LastName, "Smith");
        }
    }
}

