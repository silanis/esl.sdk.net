using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class ThankYouDialogExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ThankYouDialogExample example = new ThankYouDialogExample();
            example.Run();

            Assert.IsNotNull(example.thankYouDialogContent);
            Assert.IsNotEmpty(example.thankYouDialogContent);
        }
    }
}

