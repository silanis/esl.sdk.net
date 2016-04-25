using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class AuthenticationMethodConverterTest
    {
		private Silanis.ESL.SDK.AuthenticationMethod sdkAuthScheme1;
		private string apiAuthScheme1;

		[Test]
		public void ConvertAPIToSDK()
		{
            apiAuthScheme1 = Silanis.ESL.SDK.AuthenticationMethod.SMS.getApiValue();
			sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

			Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
		}

        [Test]
        public void ConvertAPINONEToEMAILAuthenticationMethod()
        {
            apiAuthScheme1 = "NONE";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [Test]
        public void ConvertAPICHALLENGEToCHALLENGEAuthenticationMethod()
        {
            apiAuthScheme1 = "CHALLENGE";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [Test]
        public void ConvertAPISMSToSMSAuthenticationMethod()
        {
            apiAuthScheme1 = "SMS";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [Test]
        public void ConvertAPIKBAToKBAAuthenticationMethod()
        {
            apiAuthScheme1 = "KBA";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedAuthenticationMethod()
        {
            apiAuthScheme1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }
        
        [Test]
        public void ConvertSDKToAPI()
        {
            sdkAuthScheme1 = Silanis.ESL.SDK.AuthenticationMethod.EMAIL;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual(AuthenticationMethod.EMAIL.getApiValue(), apiAuthScheme1);
        }
        
        [Test]
        public void ConvertSDKEmailToAPINone()
        {
            sdkAuthScheme1 = Silanis.ESL.SDK.AuthenticationMethod.EMAIL;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("NONE", apiAuthScheme1);
        }

        [Test]
        public void ConvertSDKChallengeToAPIChallenge()
        {
            sdkAuthScheme1 = Silanis.ESL.SDK.AuthenticationMethod.CHALLENGE;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("CHALLENGE", apiAuthScheme1);
        }

        [Test]
        public void ConvertSDKSMSToAPISMS()
        {
            sdkAuthScheme1 = Silanis.ESL.SDK.AuthenticationMethod.SMS;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("SMS", apiAuthScheme1);
        }

        [Test]
        public void ConvertSDKUnrecognizedAuthenticationMethodToAPIUnknownValue()
        {
            apiAuthScheme1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            AuthenticationMethod unrecognizedAuthenticationMethod = AuthenticationMethod.valueOf(apiAuthScheme1);
            string acutalApiScheme = new AuthenticationMethodConverter(unrecognizedAuthenticationMethod).ToAPIAuthMethod();

            Assert.AreEqual(apiAuthScheme1, acutalApiScheme);
        }
    }
}