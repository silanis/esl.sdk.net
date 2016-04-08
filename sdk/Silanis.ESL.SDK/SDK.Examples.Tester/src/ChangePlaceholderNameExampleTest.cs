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

            Assert.IsNotNull(example.RetrievedPackage.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.AreEqual(example.newPlaceholder.Name, example.RetrievedPackage.GetPlaceholder(example.PLACEHOLDER_ID).PlaceholderName);
            Assert.IsNotNull(example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.AreEqual(example.updatedPlaceholder.Name, example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER_ID).PlaceholderName);
        }
    }
}

