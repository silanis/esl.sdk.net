using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class BrandingBarConfigurationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new BrandingBarConfigurationExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.Settings.EnableOptOut, false);
            Assert.AreEqual(documentPackage.Settings.ShowDownloadButton, false);
            Assert.AreEqual(documentPackage.Settings.CeremonyLayoutSettings.GlobalNavigation, false);
            Assert.AreEqual(documentPackage.Settings.CeremonyLayoutSettings.ShowGlobalDownloadButton, false);
        }
    }
}

