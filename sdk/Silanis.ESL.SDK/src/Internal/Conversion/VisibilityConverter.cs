using System;

namespace Silanis.ESL.SDK
{
    internal class VisibilityConverter
    {
        private Silanis.ESL.SDK.Visibility sdkVisibility;
        private string apiVisibility;

        public VisibilityConverter(string apiVisibility)
        {
            this.apiVisibility = apiVisibility;
        }

        public VisibilityConverter(Silanis.ESL.SDK.Visibility sdkVisibility)
        {
            this.sdkVisibility = sdkVisibility;
        }

        public string ToAPIVisibility()
        {
            return sdkVisibility.getApiValue();
        }

        public Silanis.ESL.SDK.Visibility ToSDKVisibility()
        {
            return Silanis.ESL.SDK.Visibility.valueOf(apiVisibility);
        }
    }
}

