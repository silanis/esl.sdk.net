
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class TextAnchorPositionTest
    {
        [TestMethod]
        public void whenBuildingTextAnchorPositionWithAPIValueTOPLEFTThenTOPLEFTTextAnchorPositionIsReturned()
        {
            var expectedSDKValue = "TOPLEFT";


            var classUnderTest = TextAnchorPosition.valueOf("TOPLEFT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingTextAnchorPositionWithAPIValueTOPRIGHTThenTOPRIGHTTextAnchorPositionIsReturned()
        {
            var expectedSDKValue = "TOPRIGHT";


            var classUnderTest = TextAnchorPosition.valueOf("TOPRIGHT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingTextAnchorPositionWithAPIValueBOTTOMLEFTThenBOTTOMLEFTTextAnchorPositionIsReturned()
        {
            var expectedSDKValue = "BOTTOMLEFT";


            var classUnderTest = TextAnchorPosition.valueOf("BOTTOMLEFT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingTextAnchorPositionWithAPIValueBOTTOMRIGHTThenBOTTOMRIGHTTextAnchorPositionIsReturned()
        {
            var expectedSDKValue = "BOTTOMRIGHT";


            var classUnderTest = TextAnchorPosition.valueOf("BOTTOMRIGHT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingTextAnchorPositionWithUnknownAPIValueThenUNRECOGNIZEDTextAnchorPositionIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = TextAnchorPosition.valueOf("ThisTextAnchorPositionDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   