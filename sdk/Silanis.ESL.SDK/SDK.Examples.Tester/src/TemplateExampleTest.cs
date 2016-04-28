using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class TemplateExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new TemplateExample(  );
            example.Run();

            var template = example.EslClient.GetPackage(example.TemplateId);

            Assert.AreEqual(example.UpdatedTemplateName, template.Name);
            Assert.AreEqual(example.UpdatedTemplateDescription, template.Description);

            var documentPackage = example.EslClient.GetPackage(example.InstantiatedTemplateId);

            Assert.AreEqual(example.PackageNameForTemplate, documentPackage.Name);

            Assert.AreEqual(example.Signer1FirstName, documentPackage.GetSigner(example.email1).FirstName);
            Assert.AreEqual(example.Signer1LastName, documentPackage.GetSigner(example.email1).LastName);
            Assert.AreEqual(example.Signer1Title, documentPackage.GetSigner(example.email1).Title);
            Assert.AreEqual(example.Signer1Company, documentPackage.GetSigner(example.email1).Company);

            Assert.AreEqual(example.Signer2FirstName, documentPackage.GetSigner(example.email2).FirstName);
            Assert.AreEqual(example.Signer2LastName, documentPackage.GetSigner(example.email2).LastName);
            Assert.AreEqual(example.Signer2Title, documentPackage.GetSigner(example.email2).Title);
            Assert.AreEqual(example.Signer2Company, documentPackage.GetSigner(example.email2).Company);
        }
    }
}

