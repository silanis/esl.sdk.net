using System;

namespace Silanis.ESL.SDK
{
    internal class ExternalConverter
    {
        private External sdkExternal;
        private Silanis.ESL.API.External apiExternal;

        public ExternalConverter(Silanis.ESL.API.External apiExternal){
            this.apiExternal = apiExternal;
        }

        public ExternalConverter(External sdkExternal)
        {
            this.sdkExternal = sdkExternal;
        }

        internal Silanis.ESL.API.External ToAPIExternal()
        {
            if (sdkExternal == null)
            {
                return apiExternal;
            }
            apiExternal = new Silanis.ESL.API.External();
            apiExternal.Id = sdkExternal.Id;
            apiExternal.Provider = sdkExternal.Provider;
            apiExternal.ProviderName = sdkExternal.ProviderName;

            return apiExternal;
        }

        internal Silanis.ESL.SDK.External ToSDKExternal()
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

