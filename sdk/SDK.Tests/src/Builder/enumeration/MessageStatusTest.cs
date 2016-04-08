
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class MessageStatusTest
    {
        [TestMethod]
        public void whenBuildingMessageStatusWithAPIValueNEWThenNEWMessageStatusIsReturned()
        {
            var expectedSDKValue = "NEW";


            var classUnderTest = MessageStatus.valueOf("NEW");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingMessageStatusWithAPIValueREADThenREADMessageStatusIsReturned()
        {
            var expectedSDKValue = "READ";


            var classUnderTest = MessageStatus.valueOf("READ");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingMessageStatusWithAPIValueTRASHEDThenTRASHEDMessageStatusIsReturned()
        {
            var expectedSDKValue = "TRASHED";


            var classUnderTest = MessageStatus.valueOf("TRASHED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingMessageStatusWithUnknownAPIValueThenUNRECOGNIZEDMessageStatusIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = MessageStatus.valueOf("ThisMessageStatusDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

    }
}   