using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class RequirementStatusConverterTest
    {
        private RequirementStatus sdkRequirementStatus1;
        private string apiRequirementStatus1;

        [TestMethod]
        public void ConvertAPIINCOMPLETEoINCOMPLETERequirementStatus()
        {
            apiRequirementStatus1 = "INCOMPLETE";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIREJECTEDToREJECTEDRequirementStatus()
        {
            apiRequirementStatus1 = "REJECTED";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPICOMPLETEToCOMPLETERequirementStatus()
        {
            apiRequirementStatus1 = "COMPLETE";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedRequirementStatus()
        {
            apiRequirementStatus1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(sdkRequirementStatus1.getApiValue(), apiRequirementStatus1);
        }

        [TestMethod]
        public void ConvertSDKINCOMPLETEToAPIINCOMPLETE()
        {
            sdkRequirementStatus1 = RequirementStatus.INCOMPLETE;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("INCOMPLETE", apiRequirementStatus1);
        }

        [TestMethod]
        public void ConvertSDKREJECTEDToAPIREJECTED()
        {
            sdkRequirementStatus1 = RequirementStatus.REJECTED;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("REJECTED", apiRequirementStatus1);
        }

        [TestMethod]
        public void ConvertSDKCOMPLETEToAPICOMPLETE()
        {
            sdkRequirementStatus1 = RequirementStatus.COMPLETE;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("COMPLETE", apiRequirementStatus1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedRequirementStatusToAPIUnknownValue()
        {
            apiRequirementStatus1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            var unrecognizedRequirementStatus = RequirementStatus.valueOf(apiRequirementStatus1);
            var acutalApiValue = new RequirementStatusConverter(unrecognizedRequirementStatus).ToAPIRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, acutalApiValue);
        }

    }
}

