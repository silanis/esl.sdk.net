using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class AuthenticationMethodConverterTest
    {
		private AuthenticationMethod sdkAuthScheme1;
		private string apiAuthScheme1;

		[TestMethod]
		public void ConvertAPIToSDK()
		{
            apiAuthScheme1 = AuthenticationMethod.SMS.getApiValue();
			sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

			Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
		}

        [TestMethod]
        public void ConvertAPINONEToEMAILAuthenticationMethod()
        {
            apiAuthScheme1 = "NONE";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertAPICHALLENGEToCHALLENGEAuthenticationMethod()
        {
            apiAuthScheme1 = "CHALLENGE";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertAPISMSToSMSAuthenticationMethod()
        {
            apiAuthScheme1 = "SMS";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertAPIKBAToKBAAuthenticationMethod()
        {
            apiAuthScheme1 = "KBA";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedAuthenticationMethod()
        {
            apiAuthScheme1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            sdkAuthScheme1 = new AuthenticationMethodConverter(apiAuthScheme1).ToSDKAuthMethod();

            Assert.AreEqual(sdkAuthScheme1.getApiValue(), apiAuthScheme1);
        }
        
        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkAuthScheme1 = AuthenticationMethod.EMAIL;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual(AuthenticationMethod.EMAIL.getApiValue(), apiAuthScheme1);
        }
        
        [TestMethod]
        public void ConvertSDKEmailToAPINone()
        {
            sdkAuthScheme1 = AuthenticationMethod.EMAIL;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("NONE", apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertSDKChallengeToAPIChallenge()
        {
            sdkAuthScheme1 = AuthenticationMethod.CHALLENGE;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("CHALLENGE", apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertSDKSMSToAPISMS()
        {
            sdkAuthScheme1 = AuthenticationMethod.SMS;
            apiAuthScheme1 = new AuthenticationMethodConverter(sdkAuthScheme1).ToAPIAuthMethod();

            Assert.AreEqual("SMS", apiAuthScheme1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedAuthenticationMethodToAPIUnknownValue()
        {
            apiAuthScheme1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            var unrecognizedAuthenticationMethod = AuthenticationMethod.valueOf(apiAuthScheme1);
            var acutalApiScheme = new AuthenticationMethodConverter(unrecognizedAuthenticationMethod).ToAPIAuthMethod();

            Assert.AreEqual(apiAuthScheme1, acutalApiScheme);
        }
    }
}