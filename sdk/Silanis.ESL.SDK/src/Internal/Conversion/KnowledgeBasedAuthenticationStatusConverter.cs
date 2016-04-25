using System;

namespace Silanis.ESL.SDK
{
    internal class KnowledgeBasedAuthenticationStatusConverter
    {
        private Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus sdkKnowledgeBasedAuthenticationStatus;
        private string apiKnowledgeBasedAuthenticationStatus;

        /// <summary>
        /// Construct with API KnowledgeBasedAuthenticationStatus object involved in conversion.
        /// </summary>
        /// <param name="apiKnowledgeBasedAuthenticationStatus">API sender type.</param>
        public KnowledgeBasedAuthenticationStatusConverter(string apiKnowledgeBasedAuthenticationStatus)
        {
            this.apiKnowledgeBasedAuthenticationStatus = apiKnowledgeBasedAuthenticationStatus;
        }

        /// <summary>
        /// Construct with SDK KnowledgeBasedAuthenticationStatus object involved in conversion.
        /// </summary>
        /// <param name="sdkKnowledgeBasedAuthenticationStatus">SDK sender type.</param>
        public KnowledgeBasedAuthenticationStatusConverter(Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus sdkKnowledgeBasedAuthenticationStatus)
        {
            this.sdkKnowledgeBasedAuthenticationStatus = sdkKnowledgeBasedAuthenticationStatus;
        }

        /// <summary>
        /// Convert from SDK KnowledgeBasedAuthenticationStatus to API KnowledgeBasedAuthenticationStatus.
        /// </summary>
        /// <returns>The API sender type.</returns>
        public string ToAPIKnowledgeBasedAuthenticationStatus()
        {

            if (sdkKnowledgeBasedAuthenticationStatus == null) {
                return apiKnowledgeBasedAuthenticationStatus;
            }
            return sdkKnowledgeBasedAuthenticationStatus.getApiValue();
        }

        /// <summary>
        /// Convert from API KnowledgeBasedAuthenticationStatus to SDK KnowledgeBasedAuthenticationStatus.
        /// </summary>
        /// <returns>The SDK sender type.</returns>
        public Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus ToSDKKnowledgeBasedAuthenticationStatus()
        {
           return Silanis.ESL.SDK.KnowledgeBasedAuthenticationStatus.valueOf(apiKnowledgeBasedAuthenticationStatus);
        }
    }
}
