using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SenderStatusConverterTest
    {
        private SenderStatus sdkSenderStatus1;
        private string apiSenderStatus1;

        [TestMethod]
        public void ConvertAPIACTIVEoACTIVESenderStatus()
        {
            apiSenderStatus1 = "ACTIVE";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIINVITEDToINVITEDSenderStatus()
        {
            apiSenderStatus1 = "INVITED";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPILOCKEDToLOCKEDSenderStatus()
        {
            apiSenderStatus1 = "LOCKED";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedSenderStatus()
        {
            apiSenderStatus1 = "NEWLY_ADDED_SENDER_STATUS";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(sdkSenderStatus1.getApiValue(), apiSenderStatus1);
        }

        [TestMethod]
        public void ConvertSDKACTIVEToAPIACTIVE()
        {
            sdkSenderStatus1 = SenderStatus.ACTIVE;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("ACTIVE", apiSenderStatus1);
        }

        [TestMethod]
        public void ConvertSDKINVITEDToAPIINVITED()
        {
            sdkSenderStatus1 = SenderStatus.INVITED;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("INVITED", apiSenderStatus1);
        }

        [TestMethod]
        public void ConvertSDKLOCKEDToAPILOCKED()
        {
            sdkSenderStatus1 = SenderStatus.LOCKED;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("LOCKED", apiSenderStatus1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedSenderStatusToAPIUnknownValue()
        {
            apiSenderStatus1 = "NEWLY_ADDED_SENDER_STATUS";
            var unrecognizedSenderStatus = SenderStatus.valueOf(apiSenderStatus1);
            var acutalApiScheme = new SenderStatusConverter(unrecognizedSenderStatus).ToAPISenderStatus();

            Assert.AreEqual(apiSenderStatus1, acutalApiScheme);
        }

    }
}

