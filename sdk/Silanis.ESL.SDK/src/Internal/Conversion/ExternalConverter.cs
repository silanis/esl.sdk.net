namespace Silanis.ESL.SDK
{
    internal class ExternalConverter
    {
        private External sdkExternal;
        private API.External apiExternal;

        public ExternalConverter(API.External apiExternal){
            this.apiExternal = apiExternal;
        }

        public ExternalConverter(External sdkExternal)
        {
            this.sdkExternal = sdkExternal;
        }

        internal API.External ToAPIExternal()
        {
            if (sdkExternal == null)
            {
                return apiExternal;
            }
            apiExternal = new API.External();
            apiExternal.Id = sdkExternal.Id;
            apiExternal.Provider = sdkExternal.Provider;
            apiExternal.ProviderName = sdkExternal.ProviderName;

            return apiExternal;
        }

        internal External ToSDKExternal()
        {
            if (apiExternal == null)
            {
                return sdkExternal;
            }
            sdkExternal = new External();
            sdkExternal.Id = apiExternal.Id;
            sdkExternal.Provider = apiExternal.Provider;
            sdkExternal.ProviderName = apiExternal.ProviderName;

            return sdkExternal;
        }
    }
}

