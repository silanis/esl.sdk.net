using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class SignerSMSAuthenticationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerSMSAuthenticationExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.GetSigner(example.email1).AuthenticationMethod, AuthenticationMethod.SMS);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).ChallengeQuestion.Count, 0);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).Authentication.PhoneNumber, example.sms1);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).PhoneNumber, example.sms1);
        }
    }
}

