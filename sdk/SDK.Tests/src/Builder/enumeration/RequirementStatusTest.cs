using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    public class RequirementStatusTest
    {
        [TestMethod]
        public void whenBuildingRequirementStatusWithAPIValueDRAFTThenDRAFTRequirementStatusIsReturned()
        {
            var expectedSDKValue = "INCOMPLETE";


            var classUnderTest = RequirementStatus.valueOf("INCOMPLETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingRequirementStatusWithAPIValueREJECTEDThenREJECTEDRequirementStatusIsReturned()
        {
            var expectedSDKValue = "REJECTED";


            var classUnderTest = RequirementStatus.valueOf("REJECTED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingRequirementStatusWithAPIValueCOMPLETEThenCOMPLETERequirementStatusIsReturned()
        {
            var expectedSDKValue = "COMPLETE";


            var classUnderTest = RequirementStatus.valueOf("COMPLETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingRequirementStatusWithUnknownAPIValueThenUNRECOGNIZEDRequirementStatusIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = RequirementStatus.valueOf("ThisRequirementStatusDoesNotExistInSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

