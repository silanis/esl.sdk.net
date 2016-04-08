using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ProxyConfigurationExampleTest
    {
        [TestMethod]
        public void verifyResult()
        {
            var example = new ProxyConfigurationExample(Props.GetInstance());
            example.Run();

            var documentPackage1 = example.eslClientWithHttpProxy.GetPackage(example.packageId1);
            var documentPackage2 = example.EslClient.GetPackage(example.packageId1);
            Assert.AreEqual(example.packageId1.Id, documentPackage1.Id.Id);
            Assert.AreEqual(example.packageId1.Id, documentPackage2.Id.Id);

            var documentPackage3 = example.eslClientWithHttpProxyHasCredentials.GetPackage(example.packageId2);
            var documentPackage4 = example.EslClient.GetPackage(example.packageId2);
            Assert.AreEqual(example.packageId2.Id, documentPackage3.Id.Id);
            Assert.AreEqual(example.packageId2.Id, documentPackage4.Id.Id);
        }
    }
}

