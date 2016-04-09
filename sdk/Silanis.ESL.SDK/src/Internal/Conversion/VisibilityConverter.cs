namespace Silanis.ESL.SDK
{
    internal class VisibilityConverter
    {
        private Visibility sdkVisibility;
        private string apiVisibility;

        public VisibilityConverter(string apiVisibility)
        {
            this.apiVisibility = apiVisibility;
        }

        public VisibilityConverter(Visibility sdkVisibility)
        {
            this.sdkVisibility = sdkVisibility;
        }

        public string ToAPIVisibility()
        {
            return sdkVisibility.getApiValue();
        }

        public Visibility ToSDKVisibility()
        {
            return Visibility.valueOf(apiVisibility);
        }
    }
}

