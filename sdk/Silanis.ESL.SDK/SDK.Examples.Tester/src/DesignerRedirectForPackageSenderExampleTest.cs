using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestFixture()]
    public class DesignerRedirectForPackageSenderExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            DesignerRedirectForPackageSenderExample example = new DesignerRedirectForPackageSenderExample();
            example.Run();

            Assert.IsNotEmpty(example.GeneratedLinkToDesignerForSender);
        }
    }
}

