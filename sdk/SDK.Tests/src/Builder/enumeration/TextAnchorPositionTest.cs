using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class TextAnchorPositionTest
    {
        [Test]
        public void whenBuildingTextAnchorPositionWithAPIValueTOPLEFTThenTOPLEFTTextAnchorPositionIsReturned()
        {
            string expectedSDKValue = "TOPLEFT";


            Silanis.ESL.SDK.TextAnchorPosition classUnderTest = Silanis.ESL.SDK.TextAnchorPosition.valueOf("TOPLEFT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingTextAnchorPositionWithAPIValueTOPRIGHTThenTOPRIGHTTextAnchorPositionIsReturned()
        {
            string expectedSDKValue = "TOPRIGHT";


            Silanis.ESL.SDK.TextAnchorPosition classUnderTest = Silanis.ESL.SDK.TextAnchorPosition.valueOf("TOPRIGHT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingTextAnchorPositionWithAPIValueBOTTOMLEFTThenBOTTOMLEFTTextAnchorPositionIsReturned()
        {
            string expectedSDKValue = "BOTTOMLEFT";


            Silanis.ESL.SDK.TextAnchorPosition classUnderTest = Silanis.ESL.SDK.TextAnchorPosition.valueOf("BOTTOMLEFT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingTextAnchorPositionWithAPIValueBOTTOMRIGHTThenBOTTOMRIGHTTextAnchorPositionIsReturned()
        {
            string expectedSDKValue = "BOTTOMRIGHT";


            Silanis.ESL.SDK.TextAnchorPosition classUnderTest = Silanis.ESL.SDK.TextAnchorPosition.valueOf("BOTTOMRIGHT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingTextAnchorPositionWithUnknownAPIValueThenUNRECOGNIZEDTextAnchorPositionIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            Silanis.ESL.SDK.TextAnchorPosition classUnderTest = Silanis.ESL.SDK.TextAnchorPosition.valueOf("ThisTextAnchorPositionDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   