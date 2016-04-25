using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class KnowledgeBasedAuthenticationStatusTest
    {
        [Test]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValueNOT_YET_ATTEMPTEDThenNOT_YET_ATTEMPTEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            string expectedSDKValue = "NOT_YET_ATTEMPTED";


            KnowledgeBasedAuthenticationStatus classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("NOT_YET_ATTEMPTED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValueFAILEDThenFAILEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            string expectedSDKValue = "FAILED";


            KnowledgeBasedAuthenticationStatus classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("FAILED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValuePASSEDThenPASSEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            string expectedSDKValue = "PASSED";


            KnowledgeBasedAuthenticationStatus classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("PASSED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithUnknownAPIValueThenUNRECOGNIZEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            KnowledgeBasedAuthenticationStatus classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("ThisKnowledgeBasedAuthenticationStatusDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   