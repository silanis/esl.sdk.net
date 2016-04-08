
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SignatureStyleTest
    {
        [TestMethod]
        public void whenBuildingSignatureStyleWithAPIValueINITIALSThenINITIALSSignatureStyleIsReturned()
        {
            var expectedSDKValue = "INITIALS";


            var classUnderTest = SignatureStyle.valueOf("INITIALS");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingSignatureStyleWithAPIValueCAPTUREThenHAND_DRAWNSignatureStyleIsReturned()
        {
            var expectedSDKValue = "HAND_DRAWN";


            var classUnderTest = SignatureStyle.valueOf("CAPTURE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        
        [TestMethod]
        public void whenBuildingSignatureStyleWithAPIValueFULLNAMEThenREGULARSignatureStyleIsReturned()
        {
            var expectedSDKValue = "FULL_NAME";


            var classUnderTest = SignatureStyle.valueOf("FULLNAME");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingSignatureStyleWithUnknownAPIValueThenUNRECOGNIZEDSignatureStyleIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = SignatureStyle.valueOf("ThisSignatureStyleDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   