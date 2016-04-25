using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace SDK.Tests
{
    [TestFixture()]
    public class SenderStatusConverterTest
    {
        private Silanis.ESL.SDK.SenderStatus sdkSenderStatus1;
        private string apiSenderStatus1;

        [Test]
        public void ConvertAPIACTIVEoACTIVESenderStatus()
        {
            apiSenderStatus1 = "ACTIVE";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIINVITEDToINVITEDSenderStatus()
        {
            apiSenderStatus1 = "INVITED";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPILOCKEDToLOCKEDSenderStatus()
        {
            apiSenderStatus1 = "LOCKED";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(apiSenderStatus1, sdkSenderStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedSenderStatus()
        {
            apiSenderStatus1 = "NEWLY_ADDED_SENDER_STATUS";
            sdkSenderStatus1 = new SenderStatusConverter(apiSenderStatus1).ToSDKSenderStatus();

            Assert.AreEqual(sdkSenderStatus1.getApiValue(), apiSenderStatus1);
        }

        [Test]
        public void ConvertSDKACTIVEToAPIACTIVE()
        {
            sdkSenderStatus1 = Silanis.ESL.SDK.SenderStatus.ACTIVE;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("ACTIVE", apiSenderStatus1);
        }

        [Test]
        public void ConvertSDKINVITEDToAPIINVITED()
        {
            sdkSenderStatus1 = Silanis.ESL.SDK.SenderStatus.INVITED;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("INVITED", apiSenderStatus1);
        }

        [Test]
        public void ConvertSDKLOCKEDToAPILOCKED()
        {
            sdkSenderStatus1 = Silanis.ESL.SDK.SenderStatus.LOCKED;
            apiSenderStatus1 = new SenderStatusConverter(sdkSenderStatus1).ToAPISenderStatus();

            Assert.AreEqual("LOCKED", apiSenderStatus1);
        }

        [Test]
        public void ConvertSDKUnrecognizedSenderStatusToAPIUnknownValue()
        {
            apiSenderStatus1 = "NEWLY_ADDED_SENDER_STATUS";
            SenderStatus unrecognizedSenderStatus = SenderStatus.valueOf(apiSenderStatus1);
            string acutalApiScheme = new SenderStatusConverter(unrecognizedSenderStatus).ToAPISenderStatus();

            Assert.AreEqual(apiSenderStatus1, acutalApiScheme);
        }

    }
}

