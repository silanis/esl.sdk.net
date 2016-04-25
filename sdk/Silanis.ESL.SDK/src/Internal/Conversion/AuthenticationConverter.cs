using System;
using System.Collections.Generic;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class AuthenticationConverter
    {
        private Silanis.ESL.API.Auth apiAuth = null;
        private Silanis.ESL.SDK.Authentication sdkAuth = null;

        public AuthenticationConverter(Silanis.ESL.API.Auth apiAuth)
        {
            this.apiAuth = apiAuth;
        }

        public AuthenticationConverter(Silanis.ESL.SDK.Authentication sdkAuth)
        {
            this.sdkAuth = sdkAuth;
        }

        internal Silanis.ESL.API.Auth ToAPIAuthentication()
        {
            if (sdkAuth == null)
            {
                return apiAuth;
            }

            Silanis.ESL.API.Auth auth = new Silanis.ESL.API.Auth();

            auth.Scheme = new AuthenticationMethodConverter(sdkAuth.Method).ToAPIAuthMethod();

            foreach (Challenge challenge in sdkAuth.Challenges)
            {
                Silanis.ESL.API.AuthChallenge authChallenge = new Silanis.ESL.API.AuthChallenge();

                authChallenge.Question = challenge.Question;
                authChallenge.Answer = challenge.Answer;
                authChallenge.MaskInput = challenge.MaskOption == Challenge.MaskOptions.MaskInput;
                auth.AddChallenge(authChallenge);
            }

            if (!String.IsNullOrEmpty(sdkAuth.PhoneNumber))
            {
                Silanis.ESL.API.AuthChallenge challenge = new Silanis.ESL.API.AuthChallenge();

                challenge.Question = sdkAuth.PhoneNumber;
                auth.AddChallenge(challenge);
            }

            return auth;
        }

        internal Silanis.ESL.SDK.Authentication ToSDKAuthentication()
        {
            if (apiAuth == null)
            {
                return sdkAuth;
            }

            string telephoneNumber = null;
            Silanis.ESL.SDK.Authentication sdkAuthentication = null;

            if (apiAuth.Challenges.Count != 0)
            {
                IList<Challenge> sdkChallenges = new List<Challenge>();
                foreach (AuthChallenge apiChallenge in apiAuth.Challenges)
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
                    sdkAuthentication = new Silanis.ESL.SDK.Authentication(sdkChallenges);
                }
                else
                {
                    sdkAuthentication = new Silanis.ESL.SDK.Authentication(telephoneNumber);
                }
            }

            return sdkAuthentication;
        }
    }
}

