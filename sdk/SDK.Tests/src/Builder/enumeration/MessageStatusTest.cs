using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class MessageStatusTest
    {
        [Test]
        public void whenBuildingMessageStatusWithAPIValueNEWThenNEWMessageStatusIsReturned()
        {
            string expectedSDKValue = "NEW";


            MessageStatus classUnderTest = MessageStatus.valueOf("NEW");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingMessageStatusWithAPIValueREADThenREADMessageStatusIsReturned()
        {
            string expectedSDKValue = "READ";


            MessageStatus classUnderTest = MessageStatus.valueOf("READ");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingMessageStatusWithAPIValueTRASHEDThenTRASHEDMessageStatusIsReturned()
        {
            string expectedSDKValue = "TRASHED";


            MessageStatus classUnderTest = MessageStatus.valueOf("TRASHED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingMessageStatusWithUnknownAPIValueThenUNRECOGNIZEDMessageStatusIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            MessageStatus classUnderTest = MessageStatus.valueOf("ThisMessageStatusDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

    }
}   