
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SenderTypeTest
    {
        [TestMethod]
        public void whenBuildingSenderTypeWithAPIValueMANAGERThenMANAGERSenderTypeIsReturned()
        {
            var expectedSDKValue = "MANAGER";


            var classUnderTest = SenderType.valueOf("MANAGER");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSenderTypeWithAPIValueREGULARThenREGULARSenderTypeIsReturned()
        {
            var expectedSDKValue = "REGULAR";


            var classUnderTest = SenderType.valueOf("REGULAR");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSenderTypeWithUnknownAPIValueThenUNRECOGNIZEDSenderTypeIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = SenderType.valueOf("ThisSenderTypeDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   