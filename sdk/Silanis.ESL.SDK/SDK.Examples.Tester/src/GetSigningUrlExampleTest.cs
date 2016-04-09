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

            Assert.IsNotNull(example.SigningUrlForSigner1);
            Assert.IsTrue(example.SigningUrlForSigner1.Any());
            Assert.IsNotNull(example.SigningUrlForSigner2);
            Assert.IsTrue(example.SigningUrlForSigner2.Any());

            var stringResponse1 = HttpRequestUtil.GetUrlContent(example.SigningUrlForSigner1);
            StringAssert.Contains("Electronic Disclosures and Signatures Consent", stringResponse1);

            var stringResponse2 = HttpRequestUtil.GetUrlContent(example.SigningUrlForSigner2);
            StringAssert.Contains("Electronic Disclosures and Signatures Consent", stringResponse2);
        }
    }
}

