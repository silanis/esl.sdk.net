using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class AuthenticationMethodsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new AuthenticationMethodsExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.GetSigner(example.email1).AuthenticationMethod, AuthenticationMethod.EMAIL);
            Assert.AreEqual(documentPackage.GetSigner(example.email1).ChallengeQuestion.Count, 0);
            Assert.IsNull(documentPackage.GetSigner(example.email2).PhoneNumber);

            Assert.AreEqual(documentPackage.GetSigner(example.email2).AuthenticationMethod, AuthenticationMethod.CHALLENGE);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).ChallengeQuestion[0].Question, AuthenticationMethodsExample.QUESTION1);
            Assert.AreEqual(documentPackage.GetSigner(example.email2).ChallengeQuestion[1].Question, AuthenticationMethodsExample.QUESTION2);
            Assert.IsNull(documentPackage.GetSigner(example.email2).PhoneNumber);
          
            Assert.AreEqual(documentPackage.GetSigner(example.email3).AuthenticationMethod, AuthenticationMethod.SMS);
            Assert.AreEqual(documentPackage.GetSigner(example.email3).ChallengeQuestion.Count, 0);
            Assert.AreEqual(documentPackage.GetSigner(example.email3).PhoneNumber, example.sms3);
        }
    }
}

