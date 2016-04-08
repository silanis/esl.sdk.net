using System;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// Converter for SDK Challenge and API Challenge.
    /// </summary>
    internal class ChallengeConverter
    {
        private Silanis.ESL.API.AuthChallenge apiChallenge = null;
        private Silanis.ESL.SDK.Challenge sdkChallenge = null;

        /// <summary>
        /// Construct with API object involved in conversion.
        /// </summary>
        /// <param name="apiChallenge">API challenge.</param>
        public ChallengeConverter(Silanis.ESL.API.AuthChallenge apiChallenge)
        {
            this.apiChallenge = apiChallenge;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Silanis.ESL.SDK.ChallengeConverter"/> class.
        /// </summary>
        /// <param name="sdkChallenge">Sdk challenge.</param>
        public ChallengeConverter(Silanis.ESL.SDK.Challenge sdkChallenge)
        {
            this.sdkChallenge = sdkChallenge;
        }

        public Silanis.ESL.API.AuthChallenge ToAPIChallenge()
        {
            if (sdkChallenge == null)
            {
                return apiChallenge;
            }

            var result = new Silanis.ESL.API.AuthChallenge();
            result.Question = sdkChallenge.Question;
            result.Answer = sdkChallenge.Answer;

            switch (sdkChallenge.MaskOption)
            {
                case Challenge.MaskOptions.MaskInput:
                    result.MaskInput = true;
                    break;
                case Challenge.MaskOptions.None:
                    result.MaskInput = false;
                    break;
                default:
                    result.MaskInput = true;
                    break;
            }

            return result;
        }

        public Silanis.ESL.SDK.Challenge ToSDKChallenge()
        {
            if (apiChallenge == null)
            {
                return sdkChallenge;
            }

            Silanis.ESL.SDK.Challenge result; 

            if (apiChallenge.MaskInput.Value)
            {
                result = new Silanis.ESL.SDK.Challenge(apiChallenge.Question, apiChallenge.Answer, Challenge.MaskOptions.MaskInput);
            }
            else
            {
                result = new Silanis.ESL.SDK.Challenge(apiChallenge.Question, apiChallenge.Answer);
            }

            return result;
        }
    }
}

