using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class MessageStatusConverterTest
    {
        private Silanis.ESL.SDK.MessageStatus sdkMessageStatus1;
        private string apiMessageStatus1;

        [Test]
        public void ConvertAPINewToSDKNew()
        {
            string expectedAPIValue = "NEW";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIReadToSDKRead()
        {
            string expectedAPIValue = "READ";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPICHALLENGEToCHALLENGEMessageStatus()
        {
            string expectedAPIValue = "TRASHED";
            sdkMessageStatus1 = new MessageStatusConverter(expectedAPIValue).ToSDKMessageStatus();

            Assert.AreEqual(expectedAPIValue, sdkMessageStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedMessageStatus()
        {
            apiMessageStatus1 = "NEWLY_ADDED_MESSAGE_STATUS";
            sdkMessageStatus1 = new MessageStatusConverter(apiMessageStatus1).ToSDKMessageStatus();

            Assert.AreEqual(apiMessageStatus1, sdkMessageStatus1.getApiValue());
        }

        [Test]
        public void ConvertSDKNewToAPINew()
        {
            sdkMessageStatus1 = Silanis.ESL.SDK.MessageStatus.NEW;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("NEW", apiMessageStatus1);
        }

        [Test]
        public void ConvertSDKReadToAPIRead()
        {
            sdkMessageStatus1 = Silanis.ESL.SDK.MessageStatus.READ;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("READ", apiMessageStatus1);
        }

        [Test]
        public void ConvertSDKTrashedToAPITrashed()
        {
            sdkMessageStatus1 = Silanis.ESL.SDK.MessageStatus.TRASHED;
            apiMessageStatus1 = new MessageStatusConverter(sdkMessageStatus1).ToAPIMessageStatus();

            Assert.AreEqual("TRASHED", apiMessageStatus1);
        }

        [Test]
        public void ConvertSDKUnrecognizedMessageStatusToAPIUnknownValue()
        {
            apiMessageStatus1 = "NEWLY_ADDED_MESSAGE_STATUS";
            MessageStatus unrecognizedMessageStatus = MessageStatus.valueOf(apiMessageStatus1);
            string acutalAPIValue = new MessageStatusConverter(unrecognizedMessageStatus).ToAPIMessageStatus();

            Assert.AreEqual(apiMessageStatus1, acutalAPIValue);
        }

    }
}

