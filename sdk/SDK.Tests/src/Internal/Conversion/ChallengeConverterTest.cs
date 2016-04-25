using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class ChallengeConverterTest
    {
        private Silanis.ESL.SDK.Challenge sdkAuthChallenge1 = null;
        private Silanis.ESL.SDK.Challenge sdkAuthChallenge2 = null;
        private Silanis.ESL.API.AuthChallenge apiAuthChallenge1 = null;
        private Silanis.ESL.API.AuthChallenge apiAuthChallenge2 = null;
        private ChallengeConverter converter = null;

        [Test()]
        public void ConvertNullAPIToSDK()
        {
            apiAuthChallenge1 = null;
            converter = new ChallengeConverter(apiAuthChallenge1);
            Assert.IsNull(converter.ToSDKChallenge());
        }

        [Test()]
        public void ConvertNullSDKToSDK()
        {
            sdkAuthChallenge1 = null;
            converter = new ChallengeConverter(sdkAuthChallenge1);
            Assert.IsNull(converter.ToSDKChallenge());
        }

        [Test()]
        public void ConvertSDKToSDK()
        {
            sdkAuthChallenge1 = CreateTypicalSDKChallenge();
            converter = new ChallengeConverter(sdkAuthChallenge1);
            sdkAuthChallenge2 = converter.ToSDKChallenge();

            Assert.IsNotNull(sdkAuthChallenge2);
            Assert.AreEqual(sdkAuthChallenge2, sdkAuthChallenge1);
        }

        [Test()]
        public void ConvertAPIToSDK()
        {
            apiAuthChallenge1 = CreateTypicalAPIChallenge();
            sdkAuthChallenge1 = new ChallengeConverter(apiAuthChallenge1).ToSDKChallenge();

            Assert.IsNotNull(sdkAuthChallenge1);
            Assert.AreEqual(sdkAuthChallenge1.Question, apiAuthChallenge1.Question);
            Assert.AreEqual(sdkAuthChallenge1.Answer, apiAuthChallenge1.Answer);
            Assert.AreEqual(sdkAuthChallenge1.MaskOption, Challenge.MaskOptions.None);
        }

        [Test()]
        public void ConvertNullSDKToAPI()
        {
            sdkAuthChallenge1 = null;
            converter = new ChallengeConverter(sdkAuthChallenge1);
            Assert.IsNull(converter.ToAPIChallenge());
        }

        [Test()]
        public void ConvertNullAPIToAPI()
        {
            apiAuthChallenge1 = null;
            converter = new ChallengeConverter(apiAuthChallenge1);

            Assert.IsNull(converter.ToAPIChallenge());
        }

        [Test()]
        public void ConvertAPIToAPI()
        {
            apiAuthChallenge1 = CreateTypicalAPIChallenge();
            converter = new ChallengeConverter(apiAuthChallenge1);
            apiAuthChallenge2 = converter.ToAPIChallenge();

            Assert.IsNotNull(apiAuthChallenge2);
            Assert.AreEqual(apiAuthChallenge2, apiAuthChallenge1);
        }

        [Test()]
        public void ConvertSDKToAPI()
        {
            sdkAuthChallenge1 = CreateTypicalSDKChallenge();
            apiAuthChallenge1 = new ChallengeConverter(sdkAuthChallenge1).ToAPIChallenge();

            Assert.IsNotNull(apiAuthChallenge1);
            Assert.AreEqual(apiAuthChallenge1.Question, sdkAuthChallenge1.Question);
            Assert.AreEqual(apiAuthChallenge1.Answer, sdkAuthChallenge1.Answer);
            Assert.AreEqual(apiAuthChallenge1.MaskInput, true);
        }

        private Silanis.ESL.SDK.Challenge CreateTypicalSDKChallenge()
        {
            return new Silanis.ESL.SDK.Challenge("What is the name of your dog?", "Max", Challenge.MaskOptions.MaskInput);
        }

        private Silanis.ESL.API.AuthChallenge CreateTypicalAPIChallenge()
        {
            Silanis.ESL.API.AuthChallenge result = new Silanis.ESL.API.AuthChallenge();
            result.Question = "What is the name of your dog?";
            result.Answer = "Max";
            result.MaskInput = false;

            return result;
        }
    }
}

