using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ApplicationVersionExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ApplicationVersionExample();
            example.Run();

            Assert.IsNotNull(example.applicationVersion);
            Assert.IsTrue(example.applicationVersion.Any());
        }
    }
}

