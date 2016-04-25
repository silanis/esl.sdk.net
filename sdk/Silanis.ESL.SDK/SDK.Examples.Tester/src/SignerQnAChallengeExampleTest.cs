using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerQnAChallengeExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerQnAChallengeExample example = new SignerQnAChallengeExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            // Note that for security reasons, the backend doesn't return challenge answers, so we don't verify the answers here.
            foreach (Challenge challenge in documentPackage.GetSigner(example.email1).ChallengeQuestion)
            {
                Assert.IsTrue(String.Equals(challenge.Question, example.FIRST_QUESTION) || String.Equals(challenge.Question, example.SECOND_QUESTION));
            }
        }
    }
}

