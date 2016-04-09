using System;
using System.Collections.Generic;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class AuthenticationConverter
    {
        private Auth apiAuth = null;
        private Authentication sdkAuth = null;

        public AuthenticationConverter(Auth apiAuth)
        {
            this.apiAuth = apiAuth;
        }

        public AuthenticationConverter(Authentication sdkAuth)
        {
            this.sdkAuth = sdkAuth;
        }

        internal Auth ToAPIAuthentication()
        {
            if (sdkAuth == null)
            {
                return apiAuth;
            }

            var auth = new Auth();

            auth.Scheme = new AuthenticationMethodConverter(sdkAuth.Method).ToAPIAuthMethod();

            foreach (var challenge in sdkAuth.Challenges)
            {
                var authChallenge = new AuthChallenge();

                authChallenge.Question = challenge.Question;
                authChallenge.Answer = challenge.Answer;
                authChallenge.MaskInput = challenge.MaskOption == Challenge.MaskOptions.MaskInput;
                auth.AddChallenge(authChallenge);
            }

            if (!String.IsNullOrEmpty(sdkAuth.PhoneNumber))
            {
                var challenge = new AuthChallenge();

                challenge.Question = sdkAuth.PhoneNumber;
                auth.AddChallenge(challenge);
            }

            return auth;
        }

        internal Authentication ToSDKAuthentication()
        {
            if (apiAuth == null)
            {
                return sdkAuth;
            }

            string telephoneNumber = null;
            Authentication sdkAuthentication = null;

            if (apiAuth.Challenges.Count != 0)
            {
                IList<Challenge> sdkChallenges = new List<Challenge>();
                foreach (var apiChallenge in apiAuth.Challenges)
                {
                    if (AuthenticationMethod.CHALLENGE.getApiValue().Equals(apiAuth.Scheme))
                    {
                        sdkChallenges.Add(new ChallengeConverter(apiChallenge).ToSDKChallenge());
                    }
                    else
                    {
                        telephoneNumber = apiChallenge.Question;
                        break;
                    }
                }

                if (AuthenticationMethod.CHALLENGE.getApiValue().Equals(apiAuth.Scheme))
                {
                    sdkAuthentication = new Authentication(sdkChallenges);
                }
                else
                {
                    sdkAuthentication = new Authentication(telephoneNumber);
                }
            }

            return sdkAuthentication;
        }
    }
}

