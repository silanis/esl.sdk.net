using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageFromTemplateExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageFromTemplateExample example = new CreatePackageFromTemplateExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;
            Document document = documentPackage.GetDocument(example.DOCUMENT_NAME);

            Assert.AreEqual(document.Name, example.DOCUMENT_NAME);
            Assert.AreEqual(document.Id, example.DOCUMENT_ID);

            Assert.AreEqual(documentPackage.Name, example.PackageName);
            Assert.AreEqual(documentPackage.Description, example.PACKAGE_DESCRIPTION);
            Assert.AreEqual(documentPackage.EmailMessage, example.PACKAGE_EMAIL_MESSAGE2);

            Assert.AreEqual(documentPackage.Signers.Count, 3);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).FirstName, example.PACKAGE_SIGNER1_FIRST);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).LastName, example.PACKAGE_SIGNER1_LAST);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).FirstName, example.PACKAGE_SIGNER2_FIRST);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).LastName, example.PACKAGE_SIGNER2_LAST);

            // TODO: Make sure that this is correctly preserved.
            Assert.IsFalse(documentPackage.Settings.EnableInPerson.Value);
            Assert.IsFalse(documentPackage.Settings.EnableDecline.Value);
            Assert.IsFalse(documentPackage.Settings.EnableOptOut.Value);
            Assert.IsFalse(documentPackage.Settings.HideWatermark.Value);
        }
    }
}

