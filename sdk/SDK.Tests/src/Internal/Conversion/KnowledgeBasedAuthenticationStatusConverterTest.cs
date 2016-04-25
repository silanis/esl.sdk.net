using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class KnowledgeBasedAuthenticationStatusConverterTest
    {
        private Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus sdkKnowledgeBasedAuthenticationStatus1;
        private string apiKnowledgeBasedAuthenticationStatus1;

       
        [Test]
        public void ConvertAPINotYetAttemptedDToSDKNotYetAttempted()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NOT_YET_ATTEMPTED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, sdkKnowledgeBasedAuthenticationStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIFailedToSDKFailed()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "FAILED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, sdkKnowledgeBasedAuthenticationStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIPassedToSDKPassed()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "PASSED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(sdkKnowledgeBasedAuthenticationStatus1.getApiValue(), apiKnowledgeBasedAuthenticationStatus1);
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedKnowledgeBasedAuthenticationStatus()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NEWLY_ADDED_KBA_STATUS";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(sdkKnowledgeBasedAuthenticationStatus1.getApiValue(), apiKnowledgeBasedAuthenticationStatus1);
        }

        [Test]
        public void ConvertSDKNotYetAttemptedToAPINotYetAttempted()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus.NOT_YET_ATTEMPTED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("NOT_YET_ATTEMPTED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [Test]
        public void ConvertSDKFailedToAPIFailed()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus.FAILED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("FAILED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [Test]
        public void ConvertSDKChallengeToAPIChallenge()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus.PASSED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("PASSED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [Test]
        public void ConvertSDKUnrecognizedKnowledgeBasedAuthenticationStatusToAPIUnknownValue()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NEWLY_ADDED_KBA_STATUS";
            KnowledgeBasedAuthenticationStatus unrecognizedKnowledgeBasedAuthenticationStatus = KnowledgeBasedAuthenticationStatus.valueOf(apiKnowledgeBasedAuthenticationStatus1);
            string actualAPIValue = new KnowledgeBasedAuthenticationStatusConverter(unrecognizedKnowledgeBasedAuthenticationStatus).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, actualAPIValue);
        }

    }
}

