using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Tests
{
    [TestClass]
    public class AuthenticationConverterTest
    {
        private Authentication sdkAuth1;
        private Authentication sdkAuth2;
        private Auth apiAuth1;
        private Auth apiAuth2;
        private AuthenticationConverter converter;

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiAuth1 = null;
            converter = new AuthenticationConverter(apiAuth1);
            Assert.IsNull(converter.ToSDKAuthentication());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkAuth1 = null;
            converter = new AuthenticationConverter(sdkAuth1);
            Assert.IsNull(converter.ToSDKAuthentication());
        }

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkAuth1 = CreateTypicalSDKAuthentication();
            converter = new AuthenticationConverter(sdkAuth1);
            sdkAuth2 = converter.ToSDKAuthentication();

            Assert.IsNotNull(sdkAuth2);
            Assert.AreEqual(sdkAuth2, sdkAuth1);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiAuth1 = CreateTypicalAPIAuthentication();
            sdkAuth1 = new AuthenticationConverter(apiAuth1).ToSDKAuthentication();

            Assert.IsNotNull(sdkAuth1);
            Assert.AreEqual(sdkAuth1.Method.getApiValue(), apiAuth1.Scheme);
            Assert.AreEqual(sdkAuth1.Challenges[0].Question, apiAuth1.Challenges[0].Question);
            Assert.AreEqual(sdkAuth1.Challenges[0].Answer, apiAuth1.Challenges[0].Answer);
        }

        [TestMethod]
        public void ConvertNullSDKToAPI()
        {
            sdkAuth1 = null;
            converter = new AuthenticationConverter(sdkAuth1);
            Assert.IsNull(converter.ToAPIAuthentication());
        }

        [TestMethod]
        public void ConvertNullAPIToAPI()
        {
            apiAuth1 = null;
            converter = new AuthenticationConverter(apiAuth1);

            Assert.IsNull(converter.ToAPIAuthentication());
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            apiAuth1 = CreateTypicalAPIAuthentication();
            converter = new AuthenticationConverter(apiAuth1);
            apiAuth2 = converter.ToAPIAuthentication();

            Assert.IsNotNull(apiAuth2);
            Assert.AreEqual(apiAuth2, apiAuth1);
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkAuth1 = CreateTypicalSDKAuthentication();
            apiAuth1 = new AuthenticationConverter(sdkAuth1).ToAPIAuthentication();

            Assert.IsNotNull(apiAuth1);
            Assert.AreEqual(apiAuth1.Scheme, sdkAuth1.Method.getApiValue());
            Assert.AreEqual(apiAuth1.Challenges[0].Question, sdkAuth1.Challenges[0].Question);
            Assert.AreEqual(apiAuth1.Challenges[0].Answer, sdkAuth1.Challenges[0].Answer);
        }

        private Authentication CreateTypicalSDKAuthentication()
        {
            IList<Challenge> sdkChallenges = new List<Challenge>();
            sdkChallenges.Add(new Challenge("What is the name of your dog?", "Max"));
            var result = new Authentication(sdkChallenges);

            return result;
        }

        private Auth CreateTypicalAPIAuthentication()
        {
            var result = new Auth();
            var authChallenge = new AuthChallenge();
            authChallenge.Question = "What is the name of your dog?";
            authChallenge.Answer = "Max";
            authChallenge.MaskInput = true;
            result.AddChallenge(authChallenge);
            result.Scheme = AuthenticationMethod.CHALLENGE.getApiValue();

            return result;
        }
    }
}

