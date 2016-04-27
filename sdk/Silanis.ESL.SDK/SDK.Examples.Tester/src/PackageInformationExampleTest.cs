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

            Assert.IsNotNull(example.SupportConfiguration);

            Assert.IsNotNull(example.SupportConfiguration.Email);
            Assert.IsTrue(example.SupportConfiguration.Email.Any());

            Assert.IsNotNull(example.SupportConfiguration.Phone);
            Assert.IsTrue(example.SupportConfiguration.Phone.Any());
        }
    }
}

