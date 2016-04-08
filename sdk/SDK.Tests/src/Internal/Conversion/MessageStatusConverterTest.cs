using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class MessageStatusConverterTest
    {
        private MessageStatus sdkMessageStatus1;
        private string apiMessageStatus1;

        [TestMethod]
        public void ConvertAPINewToSDKNew()
        {
            var expectedAPIValue = "NEW";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIReadToSDKRead()
        {
            var expectedAPIValue = "READ";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPICHALLENGEToCHALLENGEMessageStatus()
        {
            var expectedAPIValue = "TRASHED";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedMessageStatus()
        {
            apiMessageStatus1 = "NEWLY_ADDED_MESSAGE_STATUS";
            sdkMessageStatus1 = new MessageStatusConverter(apiMessageStatus1).ToSDKMessageStatus();

            Assert.AreEqual(apiMessageStatus1, sdkMessageStatus1.getApiValue());
        }

        [TestMethod]
        public void ConvertSDKNewToAPINew()
        {
            sdkMessageStatus1 = MessageStatus.NEW;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("NEW", apiMessageStatus1);
        }

        [TestMethod]
        public void ConvertSDKReadToAPIRead()
        {
            sdkMessageStatus1 = MessageStatus.READ;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("READ", apiMessageStatus1);
        }

        [TestMethod]
        public void ConvertSDKTrashedToAPITrashed()
        {
            sdkMessageStatus1 = MessageStatus.TRASHED;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("TRASHED", apiMessageStatus1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedMessageStatusToAPIUnknownValue()
        {
            apiMessageStatus1 = "NEWLY_ADDED_MESSAGE_STATUS";
            var unrecognizedMessageStatus = MessageStatus.valueOf(apiMessageStatus1);
            var acutalAPIValue = new MessageStatusConverter(unrecognizedMessageStatus).ToAPIMessageStatus();

            Assert.AreEqual(apiMessageStatus1, acutalAPIValue);
        }

    }
}

