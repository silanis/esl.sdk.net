
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class KnowledgeBasedAuthenticationStatusTest
    {
        [TestMethod]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValueNOT_YET_ATTEMPTEDThenNOT_YET_ATTEMPTEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            var expectedSDKValue = "NOT_YET_ATTEMPTED";


            var classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("NOT_YET_ATTEMPTED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValueFAILEDThenFAILEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            var expectedSDKValue = "FAILED";


            var classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("FAILED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithAPIValuePASSEDThenPASSEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            var expectedSDKValue = "PASSED";


            var classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("PASSED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingKnowledgeBasedAuthenticationStatusWithUnknownAPIValueThenUNRECOGNIZEDKnowledgeBasedAuthenticationStatusIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = KnowledgeBasedAuthenticationStatus.valueOf("ThisKnowledgeBasedAuthenticationStatusDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   