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

            Assert.AreEqual(example.TemplateName, example.RetrievedTemplate.Name);
            Assert.AreEqual(2, example.RetrievedTemplate.Signers.Count);
            Assert.AreEqual(1, example.RetrievedTemplate.Placeholders.Count);
            Assert.IsNotNull(example.RetrievedTemplate.GetPlaceholder(example.PlaceholderId));
            Assert.AreEqual(2, example.RetrievedTemplate.GetDocument(example.DocumentName).Signatures.Count);

            Assert.AreEqual(2, example.UpdatedTemplate.Signers.Count);
            Assert.AreEqual(2, example.UpdatedTemplate.Placeholders.Count);
            Assert.IsNotNull(example.UpdatedTemplate.GetPlaceholder(example.PlaceholderId));
            Assert.IsNotNull(example.UpdatedTemplate.GetPlaceholder(example.Placeholder2Id));
            Assert.AreEqual(3, example.UpdatedTemplate.GetDocument(example.DocumentName).Signatures.Count);
        }
    }
}

