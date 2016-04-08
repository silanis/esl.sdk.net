using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestClass]
    public class AuthenticationMethodTest
	{
		[TestMethod]
        public void whenBuildingAuthenticationMethodWithAPIValueNONEThenEMAILAuthenticationMethodIsReturned()
        {
            var expectedSDKValue = "EMAIL";


            var classUnderTest = AuthenticationMethod.valueOf("NONE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingAuthenticationMethodWithAPIValueCHALLENGEThenCHALLENGEAuthenticationMethodIsReturned()
        {
            var expectedSDKValue = "CHALLENGE";


            var classUnderTest = AuthenticationMethod.valueOf("CHALLENGE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingAuthenticationMethodWithAPIValueSMSThenSMSAuthenticationMethodIsReturned()
        {
            var expectedSDKValue = "SMS";


            var classUnderTest = AuthenticationMethod.valueOf("SMS");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingAuthenticationMethodWithAPIValueKBAThenKBAAuthenticationMethodIsReturned()
        {
            var expectedSDKValue = "KBA";


            var classUnderTest = AuthenticationMethod.valueOf("KBA");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingAuthenticationMethodWithUnknownAPIValueThenUNRECOGNIZEDAuthenticationMethodIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = AuthenticationMethod.valueOf("ThisAuthenticationMethodDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
	}
} 	