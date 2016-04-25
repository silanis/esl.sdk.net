using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class SignatureStyleTest
    {
        [Test]
        public void whenBuildingSignatureStyleWithAPIValueINITIALSThenINITIALSSignatureStyleIsReturned()
        {
            string expectedSDKValue = "INITIALS";


            Silanis.ESL.SDK.SignatureStyle classUnderTest = Silanis.ESL.SDK.SignatureStyle.valueOf("INITIALS");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingSignatureStyleWithAPIValueCAPTUREThenHAND_DRAWNSignatureStyleIsReturned()
        {
            string expectedSDKValue = "HAND_DRAWN";


            Silanis.ESL.SDK.SignatureStyle classUnderTest = Silanis.ESL.SDK.SignatureStyle.valueOf("CAPTURE");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        
        [Test]
        public void whenBuildingSignatureStyleWithAPIValueFULLNAMEThenREGULARSignatureStyleIsReturned()
        {
            string expectedSDKValue = "FULL_NAME";


            Silanis.ESL.SDK.SignatureStyle classUnderTest = Silanis.ESL.SDK.SignatureStyle.valueOf("FULLNAME");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingSignatureStyleWithUnknownAPIValueThenUNRECOGNIZEDSignatureStyleIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            Silanis.ESL.SDK.SignatureStyle classUnderTest = Silanis.ESL.SDK.SignatureStyle.valueOf("ThisSignatureStyleDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   