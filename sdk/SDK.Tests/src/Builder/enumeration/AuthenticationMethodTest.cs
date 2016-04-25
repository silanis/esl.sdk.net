using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestFixture]
    public class AuthenticationMethodTest
	{
		[Test]
        public void whenBuildingAuthenticationMethodWithAPIValueNONEThenEMAILAuthenticationMethodIsReturned()
        {
            string expectedSDKValue = "EMAIL";


            AuthenticationMethod classUnderTest = AuthenticationMethod.valueOf("NONE");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingAuthenticationMethodWithAPIValueCHALLENGEThenCHALLENGEAuthenticationMethodIsReturned()
        {
            string expectedSDKValue = "CHALLENGE";


            AuthenticationMethod classUnderTest = AuthenticationMethod.valueOf("CHALLENGE");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingAuthenticationMethodWithAPIValueSMSThenSMSAuthenticationMethodIsReturned()
        {
            string expectedSDKValue = "SMS";


            AuthenticationMethod classUnderTest = AuthenticationMethod.valueOf("SMS");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingAuthenticationMethodWithAPIValueKBAThenKBAAuthenticationMethodIsReturned()
        {
            string expectedSDKValue = "KBA";


            AuthenticationMethod classUnderTest = AuthenticationMethod.valueOf("KBA");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingAuthenticationMethodWithUnknownAPIValueThenUNRECOGNIZEDAuthenticationMethodIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            AuthenticationMethod classUnderTest = AuthenticationMethod.valueOf("ThisAuthenticationMethodDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
	}
} 	