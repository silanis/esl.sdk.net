using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.IsTrue(example.GeneratedLinkToDesignerForSender.Any());
        }
    }
}

