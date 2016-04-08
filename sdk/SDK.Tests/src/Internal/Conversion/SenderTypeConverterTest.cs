using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestClass]
    public class SenderTypeConverterTest
    {
		private SenderType sdkSenderType1;
        private string apiSenderType1;

       
        [TestMethod]
        public void ConvertAPIRegularToRegularSenderType()
        {
            apiSenderType1 = "REGULAR";
            sdkSenderType1 = new SenderTypeConverter(apiSenderType1).ToSDKSenderType();

            Assert.AreEqual(sdkSenderType1.getApiValue(), apiSenderType1);
        }

        [TestMethod]
        public void ConvertAPIManagerToManagerSenderType()
        {
            apiSenderType1 = "MANAGER";
            sdkSenderType1 = new SenderTypeConverter(apiSenderType1).ToSDKSenderType();

            Assert.AreEqual(sdkSenderType1.getApiValue(), apiSenderType1);
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedSenderType()
        {
            apiSenderType1 = "NEWLY_ADDED_SENDER_TYPE";
            sdkSenderType1 = new SenderTypeConverter(apiSenderType1).ToSDKSenderType();

            Assert.AreEqual(sdkSenderType1.getApiValue(), apiSenderType1);
        }

        [TestMethod]
        public void ConvertSDKRegularToAPIRegular()
        {
            sdkSenderType1 = SenderType.REGULAR;
            apiSenderType1 = new SenderTypeConverter(sdkSenderType1).ToAPISenderType();

            Assert.AreEqual("REGULAR", apiSenderType1);
        }

        [TestMethod]
        public void ConvertSDKManagerToAPIManager()
        {
            sdkSenderType1 = SenderType.MANAGER;
            apiSenderType1 = new SenderTypeConverter(sdkSenderType1).ToAPISenderType();

            Assert.AreEqual("MANAGER", apiSenderType1);
        }
       
        [TestMethod]
        public void ConvertSDKUnrecognizedSenderTypeToAPIUnknownValue()
        {
            apiSenderType1 = "NEWLY_ADDED_SENDER_TYPE";
            var unrecognizedSenderType = SenderType.valueOf(apiSenderType1);
            var acutalAPIValue = new SenderTypeConverter(unrecognizedSenderType).ToAPISenderType();

            Assert.AreEqual(apiSenderType1, acutalAPIValue);
        }
    }
}

