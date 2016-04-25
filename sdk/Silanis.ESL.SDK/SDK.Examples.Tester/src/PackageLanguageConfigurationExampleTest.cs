using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class PackageLanguageConfigurationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            PackageLanguageConfigurationExample example = new PackageLanguageConfigurationExample();
            example.Run();

            DocumentPackage retrievedPackage = example.RetrievedPackage;

            Assert.AreEqual(retrievedPackage.Language.Name, "fr");
        }
    }
}

