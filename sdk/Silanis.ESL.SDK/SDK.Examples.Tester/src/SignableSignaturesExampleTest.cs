using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignableSignaturesExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignableSignaturesExample example = new SignableSignaturesExample();
            example.Run();

            Assert.AreEqual(2, example.signer1SignableSignatures.Count);
            Assert.AreEqual(example.email1, example.signer1SignableSignatures[0].SignerEmail);
            Assert.AreEqual(example.email1, example.signer1SignableSignatures[1].SignerEmail);

            Assert.AreEqual(1, example.signer2SignableSignatures.Count);
            Assert.AreEqual(example.email2, example.signer2SignableSignatures[0].SignerEmail);
        }
    }
}

