using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestClass]
    public class SigningRedirectForSignerExampleTest
    {
        /** 
        Will not be supported until later release.
        **/

        [TestMethod]
        public void VerifyResult()
        {
            var example = new SigningRedirectForSignerExample();
            example.Run();

            Assert.IsNotNull(example.GeneratedLinkToSigningForSigner);

            var stringResponse = HttpRequestUtil.GetUrlContent(example.GeneratedLinkToSigningForSigner);
            StringAssert.Contains(stringResponse, "Electronic Disclosures and Signatures Consent");
        }
    }
}

