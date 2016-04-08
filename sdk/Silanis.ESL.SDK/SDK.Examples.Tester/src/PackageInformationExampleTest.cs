using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class PackageInformationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new PackageInformationExample();
            example.Run();

            Assert.IsNotNull(example.supportConfiguration);

            Assert.IsNotNull(example.supportConfiguration.Email);
            Assert.IsTrue(example.supportConfiguration.Email.Any());

            Assert.IsNotNull(example.supportConfiguration.Phone);
            Assert.IsTrue(example.supportConfiguration.Phone.Any());
        }
    }
}

