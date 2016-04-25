using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class PackageInformationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            PackageInformationExample example = new PackageInformationExample();
            example.Run();

            Assert.IsNotNull(example.supportConfiguration);

            Assert.IsNotNull(example.supportConfiguration.Email);
            Assert.IsNotEmpty(example.supportConfiguration.Email);

            Assert.IsNotNull(example.supportConfiguration.Phone);
            Assert.IsNotEmpty(example.supportConfiguration.Phone);
        }
    }
}

