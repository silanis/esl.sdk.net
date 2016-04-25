using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class ChangePlaceholderNameExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ChangePlaceholderNameExample example = new ChangePlaceholderNameExample();
            example.Run();

            Assert.IsNotNull(example.RetrievedPackage.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.AreEqual(example.newPlaceholder.Name, example.RetrievedPackage.GetPlaceholder(example.PLACEHOLDER_ID).PlaceholderName);
            Assert.IsNotNull(example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER_ID));
            Assert.AreEqual(example.updatedPlaceholder.Name, example.updatedTemplate.GetPlaceholder(example.PLACEHOLDER_ID).PlaceholderName);
        }
    }
}

