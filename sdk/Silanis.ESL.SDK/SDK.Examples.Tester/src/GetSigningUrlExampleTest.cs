using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestClass]
    public class GetSigningUrlExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GetSigningUrlExample();
            example.Run();

            Assert.IsNotNull(example.signingUrlForSigner1);
            Assert.IsTrue(example.signingUrlForSigner1.Any());
            Assert.IsNotNull(example.signingUrlForSigner2);
            Assert.IsTrue(example.signingUrlForSigner2.Any());

            var stringResponse1 = HttpRequestUtil.GetUrlContent(example.signingUrlForSigner1);
            StringAssert.Contains(stringResponse1, "Electronic Disclosures and Signatures Consent");

            var stringResponse2 = HttpRequestUtil.GetUrlContent(example.signingUrlForSigner2);
            StringAssert.Contains(stringResponse2, "Electronic Disclosures and Signatures Consent");
        }
    }
}

