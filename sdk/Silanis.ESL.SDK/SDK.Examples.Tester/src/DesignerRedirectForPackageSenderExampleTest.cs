using Microsoft.VisualStudio.TestTools.UnitTesting;

using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestClass]
    public class DesignerRedirectForPackageSenderExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DesignerRedirectForPackageSenderExample();
            example.Run();

            Assert.IsNotNull(example.GeneratedLinkToDesignerForSender);

            var stringResponse = HttpRequestUtil.GetUrlContent(example.GeneratedLinkToDesignerForSender);
            StringAssert.Contains("Electronic Disclosures and Signatures Consent", stringResponse);
        }
    }
}

