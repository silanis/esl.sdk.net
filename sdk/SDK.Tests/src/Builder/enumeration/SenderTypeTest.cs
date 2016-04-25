using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class SenderTypeTest
    {
        [Test]
        public void whenBuildingSenderTypeWithAPIValueMANAGERThenMANAGERSenderTypeIsReturned()
        {
            string expectedSDKValue = "MANAGER";


            SenderType classUnderTest = SenderType.valueOf("MANAGER");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSenderTypeWithAPIValueREGULARThenREGULARSenderTypeIsReturned()
        {
            string expectedSDKValue = "REGULAR";


            SenderType classUnderTest = SenderType.valueOf("REGULAR");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSenderTypeWithUnknownAPIValueThenUNRECOGNIZEDSenderTypeIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            SenderType classUnderTest = SenderType.valueOf("ThisSenderTypeDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   