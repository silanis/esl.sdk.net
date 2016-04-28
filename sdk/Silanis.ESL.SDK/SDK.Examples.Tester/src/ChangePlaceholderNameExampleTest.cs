using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ChangePlaceholderNameExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ChangePlaceholderNameExample();
            example.Run();

            Assert.IsNotNull(example.RetrievedPackage.GetPlaceholder(example.PlaceholderId));
            Assert.AreEqual(example.NewPlaceholder.Name, example.RetrievedPackage.GetPlaceholder(example.PlaceholderId).PlaceholderName);
            Assert.IsNotNull(example.UpdatedTemplate.GetPlaceholder(example.PlaceholderId));
            Assert.AreEqual(example.UpdatedPlaceholder.Name, example.UpdatedTemplate.GetPlaceholder(example.PlaceholderId).PlaceholderName);
        }
    }
}

