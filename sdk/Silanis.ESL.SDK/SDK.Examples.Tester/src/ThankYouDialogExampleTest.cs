using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ThankYouDialogExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ThankYouDialogExample();
            example.Run();

            Assert.IsNotNull(example.thankYouDialogContent);
            Assert.IsTrue(example.thankYouDialogContent.Any());
        }
    }
}

