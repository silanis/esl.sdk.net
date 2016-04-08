using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class KnowledgeBasedAuthenticationStatusConverterTest
    {
        private KnowledgeBasedAuthenticationStatus sdkKnowledgeBasedAuthenticationStatus1;
        private string apiKnowledgeBasedAuthenticationStatus1;

       
        [TestMethod]
        public void ConvertAPINotYetAttemptedDToSDKNotYetAttempted()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NOT_YET_ATTEMPTED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, sdkKnowledgeBasedAuthenticationStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIFailedToSDKFailed()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "FAILED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, sdkKnowledgeBasedAuthenticationStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPassedToSDKPassed()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "PASSED";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(sdkKnowledgeBasedAuthenticationStatus1.getApiValue(), apiKnowledgeBasedAuthenticationStatus1);
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedKnowledgeBasedAuthenticationStatus()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NEWLY_ADDED_KBA_STATUS";
            sdkKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthenticationStatus1).ToSDKKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(sdkKnowledgeBasedAuthenticationStatus1.getApiValue(), apiKnowledgeBasedAuthenticationStatus1);
        }

        [TestMethod]
        public void ConvertSDKNotYetAttemptedToAPINotYetAttempted()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = KnowledgeBasedAuthenticationStatus.NOT_YET_ATTEMPTED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("NOT_YET_ATTEMPTED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [TestMethod]
        public void ConvertSDKFailedToAPIFailed()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = KnowledgeBasedAuthenticationStatus.FAILED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("FAILED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [TestMethod]
        public void ConvertSDKChallengeToAPIChallenge()
        {
            sdkKnowledgeBasedAuthenticationStatus1 = KnowledgeBasedAuthenticationStatus.PASSED;
            apiKnowledgeBasedAuthenticationStatus1 = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthenticationStatus1).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual("PASSED", apiKnowledgeBasedAuthenticationStatus1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedKnowledgeBasedAuthenticationStatusToAPIUnknownValue()
        {
            apiKnowledgeBasedAuthenticationStatus1 = "NEWLY_ADDED_KBA_STATUS";
            var unrecognizedKnowledgeBasedAuthenticationStatus = KnowledgeBasedAuthenticationStatus.valueOf(apiKnowledgeBasedAuthenticationStatus1);
            var actualAPIValue = new KnowledgeBasedAuthenticationStatusConverter(unrecognizedKnowledgeBasedAuthenticationStatus).ToAPIKnowledgeBasedAuthenticationStatus();

            Assert.AreEqual(apiKnowledgeBasedAuthenticationStatus1, actualAPIValue);
        }

    }
}

