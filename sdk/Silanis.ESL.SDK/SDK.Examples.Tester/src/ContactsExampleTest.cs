using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class ContactsExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ContactsExample example = new ContactsExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;
            Signer signer = documentPackage.GetSigner(example.email1);

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

