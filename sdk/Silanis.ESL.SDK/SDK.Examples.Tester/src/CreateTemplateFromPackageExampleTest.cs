using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CreateTemplateFromPackageExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreateTemplateFromPackageExample();
            example.Run();

            var templatePackage = example.EslClient.GetPackage(example.TemplateId);
            var document = templatePackage.GetDocument(example.DocumentName);

            Assert.AreEqual(document.Name, example.DocumentName);
            Assert.AreEqual(document.Id, example.DocumentId);

            Assert.AreEqual(templatePackage.Name, example.PackageNameNew);
            // TODO: Make sure that this is correctly preserved.
            Assert.AreEqual(templatePackage.Signers.Count, 3);
            Assert.AreEqual(templatePackage.GetSigner(example.email1).FirstName, example.PackageSigner1First);
            Assert.AreEqual(templatePackage.GetSigner(example.email1).LastName, example.PackageSigner1Last);
            Assert.AreEqual(templatePackage.GetSigner(example.email2).FirstName, example.PackageSigner2First);
            Assert.AreEqual(templatePackage.GetSigner(example.email2).LastName, example.PackageSigner2Last);
        }
    }
}

