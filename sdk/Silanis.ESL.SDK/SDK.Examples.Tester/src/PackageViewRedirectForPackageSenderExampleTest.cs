using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

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

            var stringResponse = HttpRequestUtil.GetUrlContent(example.GeneratedLinkToPackageViewForSender);
            StringAssert.Contains(example.PackageName, stringResponse);
        }
    }
}

