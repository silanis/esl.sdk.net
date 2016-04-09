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

            Assert.AreEqual(example.DraftSigningStatus, SigningStatus.INACTIVE);
            Assert.AreEqual(example.SentSigningStatus, SigningStatus.SIGNING_PENDING);
            Assert.AreEqual(example.TrashedSigningStatus, SigningStatus.DELETED);
        }
    }
}

