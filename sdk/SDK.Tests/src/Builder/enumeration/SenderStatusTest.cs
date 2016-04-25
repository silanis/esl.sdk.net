using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class SenderStatusTest
    {
        [Test]
        public void whenBuildingSenderStatusWithAPIValueACTIVEThenACTIVESenderStatusIsReturned()
        {
            string expectedSDKValue = "ACTIVE";


            SenderStatus classUnderTest = SenderStatus.valueOf("ACTIVE");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSenderStatusWithAPIValueINVITEDThenINVITEDSenderStatusIsReturned()
        {
            string expectedSDKValue = "INVITED";


            SenderStatus classUnderTest = SenderStatus.valueOf("INVITED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSenderStatusWithAPIValueLOCKEDThenLOCKEDSenderStatusIsReturned()
        {
            string expectedSDKValue = "LOCKED";


            SenderStatus classUnderTest = SenderStatus.valueOf("LOCKED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSenderStatusWithUnknownAPIValueThenUNRECOGNIZEDSenderStatusIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            SenderStatus classUnderTest = SenderStatus.valueOf("ThisSenderStatusDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   