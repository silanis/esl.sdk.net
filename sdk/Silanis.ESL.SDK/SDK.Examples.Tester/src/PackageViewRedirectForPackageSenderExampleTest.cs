using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class PackageViewRedirectForPackageSenderExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new PackageViewRedirectForPackageSenderExample();
            example.Run();

            Assert.IsNotNull(example.GeneratedLinkToPackageViewForSender);
            Assert.IsTrue(example.GeneratedLinkToPackageViewForSender.Any());


        }
    }
}

