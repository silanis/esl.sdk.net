using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class UpdateTemplateWithPlaceholderExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new UpdateTemplateWithPlaceholderExample();
            example.Run();

            Assert.AreEqual(example.TEMPLATE_NAME, example.retrievedTemplate.Name);
            Assert.AreEqual(2, example.retrievedTemplate.Signers.Count);
            Assert.AreEqual(1, example.retrievedTemplate.Placeholders.Count);
            Assert.IsNotNull(example.retrievedTemplate.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.AreEqual(2, example.retrievedTemplate.GetDocument(example.DOCUMENT_NAME).Signatures.Count);

            Assert.AreEqual(2, example.updatedTemplate.Signers.Count);
            Assert.AreEqual(2, example.updatedTemplate.Placeholders.Count);
            Assert.IsNotNull(example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.IsNotNull(example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER2_ID));
            Assert.AreEqual(3, example.updatedTemplate.GetDocument(example.DOCUMENT_NAME).Signatures.Count);
        }
    }
}

