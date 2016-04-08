using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class GetSigningStatusExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GetSigningStatusExample();
            example.Run();

            Assert.AreEqual(example.draftSigningStatus, SigningStatus.INACTIVE);
            Assert.AreEqual(example.sentSigningStatus, SigningStatus.SIGNING_PENDING);
            Assert.AreEqual(example.trashedSigningStatus, SigningStatus.DELETED);
        }
    }
}

