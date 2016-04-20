using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestFixture()]
    public class DesignerRedirectForApiKeyExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            DesignerRedirectForApiKeyExample example = new DesignerRedirectForApiKeyExample();
            example.Run();

            Assert.IsNotEmpty(example.GeneratedLinkToDesignerForApiKey);
        }
    }
}

