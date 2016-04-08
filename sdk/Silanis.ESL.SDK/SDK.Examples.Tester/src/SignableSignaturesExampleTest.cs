using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignableSignaturesExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignableSignaturesExample();
            example.Run();

            Assert.AreEqual(2, example.signer1SignableSignatures.Count);
            Assert.AreEqual(example.email1, example.signer1SignableSignatures[0].SignerEmail);
            Assert.AreEqual(example.email1, example.signer1SignableSignatures[1].SignerEmail);

            Assert.AreEqual(1, example.signer2SignableSignatures.Count);
            Assert.AreEqual(example.email2, example.signer2SignableSignatures[0].SignerEmail);
        }
    }
}

