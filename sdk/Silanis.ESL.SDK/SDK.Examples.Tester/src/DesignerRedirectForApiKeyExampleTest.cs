using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.IsTrue(example.GeneratedLinkToDesignerForApiKey.Any());
        }
    }
}

