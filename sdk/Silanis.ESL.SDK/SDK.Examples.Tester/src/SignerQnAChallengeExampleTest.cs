using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerQnAChallengeExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerQnAChallengeExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            // Note that for security reasons, the backend doesn't return challenge answers, so we don't verify the answers here.
            foreach (var challenge in documentPackage.GetSigner(example.email1).ChallengeQuestion)
            {
                Assert.IsTrue(String.Equals(challenge.Question, example.FirstQuestion) || String.Equals(challenge.Question, example.SecondQuestion));
            }
        }
    }
}

