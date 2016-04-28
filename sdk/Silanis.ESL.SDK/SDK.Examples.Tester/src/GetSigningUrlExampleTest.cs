using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestClass]
    public class GetSigningUrlExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GetSigningUrlExample();
            example.Run();

            Assert.IsNotNull(example.SigningUrlForSigner1);
            Assert.IsTrue(example.SigningUrlForSigner1.Any());
            Assert.IsNotNull(example.SigningUrlForSigner2);
            Assert.IsTrue(example.SigningUrlForSigner2.Any());

        }
    }
}

