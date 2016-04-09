namespace Silanis.ESL.SDK.src.Internal.Conversion
{
    class TextAnchorPositionConverter
    {
        private TextAnchorPosition sdkPosition = null;
        private string apiAnchorPoint = null;

        public TextAnchorPositionConverter(TextAnchorPosition sdkPosition)
        {
            this.sdkPosition = sdkPosition;
        }

        public TextAnchorPositionConverter(string apiAnchorPoint)
        {
            this.apiAnchorPoint = apiAnchorPoint;
        }

        public TextAnchorPosition ToSDKTextAnchorPosition()
        {
            if (sdkPosition != null)
            {
                return sdkPosition;
            }
            else
            {
                return TextAnchorPosition.valueOf(apiAnchorPoint);
            }
        }

        public string ToAPIAnchorPoint()
        {
            if (apiAnchorPoint != null)
            {
                return apiAnchorPoint;
            }
            if (null == sdkPosition) {
                return null;
            }
            return sdkPosition.getApiValue();
        }
    }
}
