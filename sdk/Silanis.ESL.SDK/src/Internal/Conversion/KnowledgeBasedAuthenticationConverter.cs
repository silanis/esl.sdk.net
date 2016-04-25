using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class KnowledgeBasedAuthenticationConverter
    {
        private Silanis.ESL.SDK.KnowledgeBasedAuthentication sdkKnowledgeBasedAuthentication = null;
        private Silanis.ESL.API.KnowledgeBasedAuthentication apiKnowledgeBasedAuthentication = null;

        /// <summary>
        /// Construct with API KnowledgeBasedAuthentication object involved in conversion.
        /// </summary>
        /// <param name="apiKnowledgeBasedAuthentication">API knowledge based authentication.</param>
        public KnowledgeBasedAuthenticationConverter(Silanis.ESL.API.KnowledgeBasedAuthentication apiKnowledgeBasedAuthentication)
        {
            this.apiKnowledgeBasedAuthentication = apiKnowledgeBasedAuthentication;
        }

        /// <summary>
        /// Construct with SDK KnowledgeBasedAuthentication object involved in conversion.
        /// </summary>
        /// <param name="sdkKnowledgeBasedAuthentication">SDK knowledge based authentication.</param>
        public KnowledgeBasedAuthenticationConverter(Silanis.ESL.SDK.KnowledgeBasedAuthentication sdkKnowledgeBasedAuthentication)
        {
            this.sdkKnowledgeBasedAuthentication = sdkKnowledgeBasedAuthentication;
        }

        /// <summary>
        /// Convert from SDK KnowledgeBasedAuthentication to API KnowledgeBasedAuthentication.
        /// </summary>
        /// <returns>The API knowledge based authentication.</returns>
        public Silanis.ESL.API.KnowledgeBasedAuthentication ToAPIKnowledgeBasedAuthentication()
        {
            if (sdkKnowledgeBasedAuthentication == null)
            {
                return apiKnowledgeBasedAuthentication;
            }

            Silanis.ESL.API.KnowledgeBasedAuthentication result = new Silanis.ESL.API.KnowledgeBasedAuthentication();
            result.SignerInformationForEquifaxCanada = new SignerInformationForEquifaxCanadaConverter(sdkKnowledgeBasedAuthentication.SignerInformationForEquifaxCanada).ToAPISignerInformationForEquifaxCanada();
            result.SignerInformationForEquifaxUSA = new SignerInformationForEquifaxUSAConverter(sdkKnowledgeBasedAuthentication.SignerInformationForEquifaxUSA).ToAPISignerInformationForEquifaxUSA();
            result.KnowledgeBasedAuthenticationStatus = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthentication.KnowledgeBasedAuthenticationStatus).ToAPIKnowledgeBasedAuthenticationStatus();

            return result;
        }

        /// <summary>
        /// Convert from API KnowledgeBasedAuthentication to SDK KnowledgeBasedAuthentication.
        /// </summary>
        /// <returns>The SDK knowledge based authentication.</returns>
        public Silanis.ESL.SDK.KnowledgeBasedAuthentication ToSDKKnowledgeBasedAuthentication()
        {
            if (apiKnowledgeBasedAuthentication == null)
            {
                return sdkKnowledgeBasedAuthentication;
            }

            Silanis.ESL.SDK.KnowledgeBasedAuthentication result = new Silanis.ESL.SDK.KnowledgeBasedAuthentication();
            result.SignerInformationForEquifaxCanada = new SignerInformationForEquifaxCanadaConverter(apiKnowledgeBasedAuthentication.SignerInformationForEquifaxCanada).ToSDKSignerInformationForEquifaxCanada();
            result.SignerInformationForEquifaxUSA = new SignerInformationForEquifaxUSAConverter(apiKnowledgeBasedAuthentication.SignerInformationForEquifaxUSA).ToSDKSignerInformationForEquifaxUSA();
            result.KnowledgeBasedAuthenticationStatus = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthentication.KnowledgeBasedAuthenticationStatus).ToSDKKnowledgeBasedAuthenticationStatus();
            return result;
        }
    }
}
