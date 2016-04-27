using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CreatePackageFromTemplateExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreatePackageFromTemplateExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;
            var document = documentPackage.GetDocument(example.DocumentName);

            Assert.AreEqual(document.Name, example.DocumentName);
            Assert.AreEqual(document.Id, example.DocumentId);

            Assert.AreEqual(documentPackage.Name, example.PackageName);
            Assert.AreEqual(documentPackage.Description, example.PackageDescription);
            Assert.AreEqual(documentPackage.EmailMessage, example.PackageEmailMessage2);

            Assert.AreEqual(documentPackage.Signers.Count, 3);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).FirstName, example.PackageSigner1First);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).LastName, example.PackageSigner1Last);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).FirstName, example.PackageSigner2First);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).LastName, example.PackageSigner2Last);

            // TODO: Make sure that this is correctly preserved.
            Assert.IsFalse(documentPackage.Settings.EnableInPerson.Value);
            Assert.IsFalse(documentPackage.Settings.EnableDecline.Value);
            Assert.IsFalse(documentPackage.Settings.EnableOptOut.Value);
            Assert.IsFalse(documentPackage.Settings.HideWatermark.Value);
        }
    }
}

