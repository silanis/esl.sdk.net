using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    public class RequirementStatusTest
    {
        [Test]
        public void whenBuildingRequirementStatusWithAPIValueDRAFTThenDRAFTRequirementStatusIsReturned()
        {
            string expectedSDKValue = "INCOMPLETE";


            RequirementStatus classUnderTest = RequirementStatus.valueOf("INCOMPLETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingRequirementStatusWithAPIValueREJECTEDThenREJECTEDRequirementStatusIsReturned()
        {
            string expectedSDKValue = "REJECTED";


            RequirementStatus classUnderTest = RequirementStatus.valueOf("REJECTED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingRequirementStatusWithAPIValueCOMPLETEThenCOMPLETERequirementStatusIsReturned()
        {
            string expectedSDKValue = "COMPLETE";


            RequirementStatus classUnderTest = RequirementStatus.valueOf("COMPLETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingRequirementStatusWithUnknownAPIValueThenUNRECOGNIZEDRequirementStatusIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            RequirementStatus classUnderTest = RequirementStatus.valueOf("ThisRequirementStatusDoesNotExistInSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

