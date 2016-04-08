using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class PackageLanguageConfigurationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new PackageLanguageConfigurationExample();
            example.Run();

            var retrievedPackage = example.RetrievedPackage;

            Assert.AreEqual(retrievedPackage.Language.Name, "fr");
        }
    }
}

