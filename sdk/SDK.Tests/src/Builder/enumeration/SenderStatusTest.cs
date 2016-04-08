
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SenderStatusTest
    {
        [TestMethod]
        public void whenBuildingSenderStatusWithAPIValueACTIVEThenACTIVESenderStatusIsReturned()
        {
            var expectedSDKValue = "ACTIVE";


            var classUnderTest = SenderStatus.valueOf("ACTIVE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSenderStatusWithAPIValueINVITEDThenINVITEDSenderStatusIsReturned()
        {
            var expectedSDKValue = "INVITED";


            var classUnderTest = SenderStatus.valueOf("INVITED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSenderStatusWithAPIValueLOCKEDThenLOCKEDSenderStatusIsReturned()
        {
            var expectedSDKValue = "LOCKED";


            var classUnderTest = SenderStatus.valueOf("LOCKED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSenderStatusWithUnknownAPIValueThenUNRECOGNIZEDSenderStatusIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = SenderStatus.valueOf("ThisSenderStatusDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   