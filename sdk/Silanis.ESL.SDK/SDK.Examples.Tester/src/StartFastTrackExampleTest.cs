using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class StartFastTrackExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new StartFastTrackExample();
            example.Run();
            Assert.IsNotNull(example.SigningUrl);
            Assert.IsTrue(example.SigningUrl.Any());
        }
    }
}

