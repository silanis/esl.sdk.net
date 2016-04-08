using System;

namespace Silanis.ESL.SDK
{
    internal class SupportConfigurationConverter
    {
        private SupportConfiguration sdkSupportConfiguration;
        private Silanis.ESL.API.SupportConfiguration apiSupportConfiguration;

        public SupportConfigurationConverter(SupportConfiguration sdkSupportConfiguration)
        {
            this.sdkSupportConfiguration = sdkSupportConfiguration;
        }

        public SupportConfigurationConverter(Silanis.ESL.API.SupportConfiguration apiSupportConfiguration)
        {
            this.apiSupportConfiguration = apiSupportConfiguration;
        }

        public SupportConfiguration ToSDKSupportConfiguration()
        {
            if (apiSupportConfiguration == null)
            {
                return sdkSupportConfiguration;
            }

            var result = new SupportConfiguration();
            result.Email = apiSupportConfiguration.Email;
            result.Phone = apiSupportConfiguration.Phone;
            return result;
        }

        public Silanis.ESL.API.SupportConfiguration ToAPISupportConfiguration()
        {
            if (sdkSupportConfiguration == null)
            {
                return apiSupportConfiguration;
            }

            var result = new Silanis.ESL.API.SupportConfiguration();
            result.Email = sdkSupportConfiguration.Email;
            result.Phone = sdkSupportConfiguration.Phone;
            return result;
        }
    }
}

