using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class GetSigningStatusExampleTest
    {
        [Test()]
        [Category("NotFor60")]
        public void VerifyResult()
        {
            GetSigningStatusExample example = new GetSigningStatusExample();
            example.Run();

            Assert.AreEqual(example.draftSigningStatus, SigningStatus.INACTIVE);
            Assert.AreEqual(example.sentSigningStatus, SigningStatus.SIGNING_PENDING);
            Assert.AreEqual(example.trashedSigningStatus, SigningStatus.DELETED);
        }
    }
}

