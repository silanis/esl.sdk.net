using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// Converter for SDK Challenge and API Challenge.
    /// </summary>
    internal class ChallengeConverter
    {
        private AuthChallenge apiChallenge = null;
        private Challenge sdkChallenge = null;

        /// <summary>
        /// Construct with API object involved in conversion.
        /// </summary>
        /// <param name="apiChallenge">API challenge.</param>
        public ChallengeConverter(AuthChallenge apiChallenge)
        {
            this.apiChallenge = apiChallenge;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Silanis.ESL.SDK.ChallengeConverter"/> class.
        /// </summary>
        /// <param name="sdkChallenge">Sdk challenge.</param>
        public ChallengeConverter(Challenge sdkChallenge)
        {
            this.sdkChallenge = sdkChallenge;
        }

        public AuthChallenge ToAPIChallenge()
        {
            if (sdkChallenge == null)
            {
                return apiChallenge;
            }

            var result = new AuthChallenge();
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

        public Challenge ToSDKChallenge()
        {
            if (apiChallenge == null)
            {
                return sdkChallenge;
            }

            Challenge result; 

            if (apiChallenge.MaskInput.Value)
            {
                result = new Challenge(apiChallenge.Question, apiChallenge.Answer, Challenge.MaskOptions.MaskInput);
            }
            else
            {
                result = new Challenge(apiChallenge.Question, apiChallenge.Answer);
            }

            return result;
        }
    }
}

