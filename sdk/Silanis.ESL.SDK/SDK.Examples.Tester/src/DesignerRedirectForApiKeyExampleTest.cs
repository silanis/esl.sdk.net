using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestClass]
    public class DesignerRedirectForApiKeyExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DesignerRedirectForApiKeyExample();
            example.Run();

            Assert.IsNotNull(example.GeneratedLinkToDesignerForApiKey);

            var stringResponse = HttpRequestUtil.GetUrlContent(example.GeneratedLinkToDesignerForApiKey);
            StringAssert.Contains("Electronic Disclosures and Signatures Consent", stringResponse);
        }
    }
}

