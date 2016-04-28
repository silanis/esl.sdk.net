using System.Linq;
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

            Assert.IsTrue(example.GeneratedLinkToSigningForSigner.Any());
        }
    }
}

