namespace Silanis.ESL.SDK
{
    internal class SupportConfigurationConverter
    {
        private SupportConfiguration sdkSupportConfiguration;
        private API.SupportConfiguration apiSupportConfiguration;

        public SupportConfigurationConverter(SupportConfiguration sdkSupportConfiguration)
        {
            this.sdkSupportConfiguration = sdkSupportConfiguration;
        }

        public SupportConfigurationConverter(API.SupportConfiguration apiSupportConfiguration)
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

        public API.SupportConfiguration ToAPISupportConfiguration()
        {
            if (sdkSupportConfiguration == null)
            {
                return apiSupportConfiguration;
            }

            var result = new API.SupportConfiguration();
            result.Email = sdkSupportConfiguration.Email;
            result.Phone = sdkSupportConfiguration.Phone;
            return result;
        }
    }
}

