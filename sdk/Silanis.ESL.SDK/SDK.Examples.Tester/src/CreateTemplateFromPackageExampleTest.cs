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
            var document = templatePackage.GetDocument(example.DOCUMENT_NAME);

            Assert.AreEqual(document.Name, example.DOCUMENT_NAME);
            Assert.AreEqual(document.Id, example.DOCUMENT_ID);

            Assert.AreEqual(templatePackage.Name, example.PACKAGE_NAME_NEW);
            // TODO: Make sure that this is correctly preserved.
            Assert.AreEqual(templatePackage.Signers.Count, 3);
            Assert.AreEqual(templatePackage.GetSigner(example.email1).FirstName, example.PACKAGE_SIGNER1_FIRST);
            Assert.AreEqual(templatePackage.GetSigner(example.email1).LastName, example.PACKAGE_SIGNER1_LAST);
            Assert.AreEqual(templatePackage.GetSigner(example.email2).FirstName, example.PACKAGE_SIGNER2_FIRST);
            Assert.AreEqual(templatePackage.GetSigner(example.email2).LastName, example.PACKAGE_SIGNER2_LAST);
        }
    }
}

