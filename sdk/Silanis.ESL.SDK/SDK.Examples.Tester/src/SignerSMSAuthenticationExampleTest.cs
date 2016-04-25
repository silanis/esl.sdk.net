using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerSMSAuthenticationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerSMSAuthenticationExample example = new SignerSMSAuthenticationExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.GetSigner(example.email1).AuthenticationMethod, AuthenticationMethod.SMS);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).ChallengeQuestion.Count, 0);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).Authentication.PhoneNumber, example.sms1);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).PhoneNumber, example.sms1);
        }
    }
}

