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

            var documentPackage1 = example.EslClientWithHttpProxy.GetPackage(example.PackageId1);
            var documentPackage2 = example.EslClient.GetPackage(example.PackageId1);
            Assert.AreEqual(example.PackageId1.Id, documentPackage1.Id.Id);
            Assert.AreEqual(example.PackageId1.Id, documentPackage2.Id.Id);

            var documentPackage3 = example.EslClientWithHttpProxyHasCredentials.GetPackage(example.PackageId2);
            var documentPackage4 = example.EslClient.GetPackage(example.PackageId2);
            Assert.AreEqual(example.PackageId2.Id, documentPackage3.Id.Id);
            Assert.AreEqual(example.PackageId2.Id, documentPackage4.Id.Id);
        }
    }
}

