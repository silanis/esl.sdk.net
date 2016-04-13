using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

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

            Assert.IsNotNull(example.signingUrl);
            Assert.IsTrue(example.signingUrl.Any());
            
            var stringResponse1 = HttpRequestUtil.GetUrlContent(example.signingUrl);
            StringAssert.Contains(stringResponse1, "Electronic Disclosures and Signatures Consent");
        }
    }
}

