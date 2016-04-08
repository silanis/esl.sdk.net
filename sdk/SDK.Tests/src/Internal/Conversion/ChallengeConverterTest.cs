using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class ChallengeConverterTest
    {
        private Challenge sdkAuthChallenge1;
        private Challenge sdkAuthChallenge2;
        private AuthChallenge apiAuthChallenge1;
        private AuthChallenge apiAuthChallenge2;
        private ChallengeConverter converter;

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiAuthChallenge1 = null;
            converter = new ChallengeConverter(apiAuthChallenge1);
            Assert.IsNull(converter.ToSDKChallenge());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkAuthChallenge1 = null;
            converter = new ChallengeConverter(sdkAuthChallenge1);
            Assert.IsNull(converter.ToSDKChallenge());
        }

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkAuthChallenge1 = CreateTypicalSDKChallenge();
            converter = new ChallengeConverter(sdkAuthChallenge1);
            sdkAuthChallenge2 = converter.ToSDKChallenge();

            Assert.IsNotNull(sdkAuthChallenge2);
            Assert.AreEqual(sdkAuthChallenge2, sdkAuthChallenge1);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiAuthChallenge1 = CreateTypicalAPIChallenge();
            sdkAuthChallenge1 = new ChallengeConverter(apiAuthChallenge1).ToSDKChallenge();

            Assert.IsNotNull(sdkAuthChallenge1);
            Assert.AreEqual(sdkAuthChallenge1.Question, apiAuthChallenge1.Question);
            Assert.AreEqual(sdkAuthChallenge1.Answer, apiAuthChallenge1.Answer);
            Assert.AreEqual(sdkAuthChallenge1.MaskOption, Challenge.MaskOptions.None);
        }

        [TestMethod]
        public void ConvertNullSDKToAPI()
        {
            sdkAuthChallenge1 = null;
            converter = new ChallengeConverter(sdkAuthChallenge1);
            Assert.IsNull(converter.ToAPIChallenge());
        }

        [TestMethod]
        public void ConvertNullAPIToAPI()
        {
            apiAuthChallenge1 = null;
            converter = new ChallengeConverter(apiAuthChallenge1);

            Assert.IsNull(converter.ToAPIChallenge());
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            apiAuthChallenge1 = CreateTypicalAPIChallenge();
            converter = new ChallengeConverter(apiAuthChallenge1);
            apiAuthChallenge2 = converter.ToAPIChallenge();

            Assert.IsNotNull(apiAuthChallenge2);
            Assert.AreEqual(apiAuthChallenge2, apiAuthChallenge1);
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkAuthChallenge1 = CreateTypicalSDKChallenge();
            apiAuthChallenge1 = new ChallengeConverter(sdkAuthChallenge1).ToAPIChallenge();

            Assert.IsNotNull(apiAuthChallenge1);
            Assert.AreEqual(apiAuthChallenge1.Question, sdkAuthChallenge1.Question);
            Assert.AreEqual(apiAuthChallenge1.Answer, sdkAuthChallenge1.Answer);
            Assert.AreEqual(apiAuthChallenge1.MaskInput, true);
        }

        private Challenge CreateTypicalSDKChallenge()
        {
            return new Challenge("What is the name of your dog?", "Max", Challenge.MaskOptions.MaskInput);
        }

        private AuthChallenge CreateTypicalAPIChallenge()
        {
            var result = new AuthChallenge();
            result.Question = "What is the name of your dog?";
            result.Answer = "Max";
            result.MaskInput = false;

            return result;
        }
    }
}

