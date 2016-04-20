using System;
using NUnit.Framework;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestFixture()]
    public class PackageViewRedirectForPackageSenderExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            PackageViewRedirectForPackageSenderExample example = new PackageViewRedirectForPackageSenderExample();
            example.Run();

            Assert.IsNotEmpty(example.generatedLinkToPackageViewForSender);
        }
    }
}

