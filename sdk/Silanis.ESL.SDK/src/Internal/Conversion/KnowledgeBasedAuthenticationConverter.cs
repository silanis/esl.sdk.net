namespace Silanis.ESL.SDK
{
    internal class KnowledgeBasedAuthenticationConverter
    {
        private KnowledgeBasedAuthentication sdkKnowledgeBasedAuthentication = null;
        private API.KnowledgeBasedAuthentication apiKnowledgeBasedAuthentication = null;

        /// <summary>
        /// Construct with API KnowledgeBasedAuthentication object involved in conversion.
        /// </summary>
        /// <param name="apiKnowledgeBasedAuthentication">API knowledge based authentication.</param>
        public KnowledgeBasedAuthenticationConverter(API.KnowledgeBasedAuthentication apiKnowledgeBasedAuthentication)
        {
            this.apiKnowledgeBasedAuthentication = apiKnowledgeBasedAuthentication;
        }

        /// <summary>
        /// Construct with SDK KnowledgeBasedAuthentication object involved in conversion.
        /// </summary>
        /// <param name="sdkKnowledgeBasedAuthentication">SDK knowledge based authentication.</param>
        public KnowledgeBasedAuthenticationConverter(KnowledgeBasedAuthentication sdkKnowledgeBasedAuthentication)
        {
            this.sdkKnowledgeBasedAuthentication = sdkKnowledgeBasedAuthentication;
        }

        /// <summary>
        /// Convert from SDK KnowledgeBasedAuthentication to API KnowledgeBasedAuthentication.
        /// </summary>
        /// <returns>The API knowledge based authentication.</returns>
        public API.KnowledgeBasedAuthentication ToAPIKnowledgeBasedAuthentication()
        {
            if (sdkKnowledgeBasedAuthentication == null)
            {
                return apiKnowledgeBasedAuthentication;
            }

            var result = new API.KnowledgeBasedAuthentication();
            result.SignerInformationForEquifaxCanada = new SignerInformationForEquifaxCanadaConverter(sdkKnowledgeBasedAuthentication.SignerInformationForEquifaxCanada).ToAPISignerInformationForEquifaxCanada();
            result.SignerInformationForEquifaxUSA = new SignerInformationForEquifaxUSAConverter(sdkKnowledgeBasedAuthentication.SignerInformationForEquifaxUSA).ToAPISignerInformationForEquifaxUSA();
            result.KnowledgeBasedAuthenticationStatus = new KnowledgeBasedAuthenticationStatusConverter(sdkKnowledgeBasedAuthentication.KnowledgeBasedAuthenticationStatus).ToAPIKnowledgeBasedAuthenticationStatus();

            return result;
        }

        /// <summary>
        /// Convert from API KnowledgeBasedAuthentication to SDK KnowledgeBasedAuthentication.
        /// </summary>
        /// <returns>The SDK knowledge based authentication.</returns>
        public KnowledgeBasedAuthentication ToSDKKnowledgeBasedAuthentication()
        {
            if (apiKnowledgeBasedAuthentication == null)
            {
                return sdkKnowledgeBasedAuthentication;
            }

            var result = new KnowledgeBasedAuthentication();
            result.SignerInformationForEquifaxCanada = new SignerInformationForEquifaxCanadaConverter(apiKnowledgeBasedAuthentication.SignerInformationForEquifaxCanada).ToSDKSignerInformationForEquifaxCanada();
            result.SignerInformationForEquifaxUSA = new SignerInformationForEquifaxUSAConverter(apiKnowledgeBasedAuthentication.SignerInformationForEquifaxUSA).ToSDKSignerInformationForEquifaxUSA();
            result.KnowledgeBasedAuthenticationStatus = new KnowledgeBasedAuthenticationStatusConverter(apiKnowledgeBasedAuthentication.KnowledgeBasedAuthenticationStatus).ToSDKKnowledgeBasedAuthenticationStatus();
            return result;
        }
    }
}
