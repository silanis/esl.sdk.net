using Silanis.ESL.API;

namespace Silanis.ESL.SDK.src.Internal.Conversion
{
    class TextAnchorConverter
    {
        private TextAnchor sdkTextAnchor = null;
        private ExtractAnchor apiExtractAnchor = null;

        public TextAnchorConverter(TextAnchor sdkTextAnchor)
        {
            this.sdkTextAnchor = sdkTextAnchor;
        }

        public TextAnchorConverter(ExtractAnchor apiExtractAnchor)
        {
            this.apiExtractAnchor = apiExtractAnchor;
        }

        public TextAnchor ToSDKTextAnchor()
        {
            if (apiExtractAnchor == null)
            {
                return sdkTextAnchor;
            }
            else
            {
                var result = new TextAnchor();

                result.Position = new TextAnchorPositionConverter(apiExtractAnchor.AnchorPoint).ToSDKTextAnchorPosition();
                
                if ( apiExtractAnchor.Index.HasValue )
                    result.Occurrence = apiExtractAnchor.Index.Value;
                    
                result.AnchorText = apiExtractAnchor.Text;
                
                if (apiExtractAnchor.CharacterIndex.HasValue)
                    result.Character = apiExtractAnchor.CharacterIndex.Value;
                    
                if (apiExtractAnchor.LeftOffset.HasValue)
                    result.XOffset = apiExtractAnchor.LeftOffset.Value;
                    
                if (apiExtractAnchor.TopOffset.HasValue)
                    result.YOffset = apiExtractAnchor.TopOffset.Value;
                    
                if (apiExtractAnchor.Width.HasValue)
                    result.Width = apiExtractAnchor.Width.Value;
                    
                if (apiExtractAnchor.Height.HasValue)
                    result.Height = apiExtractAnchor.Height.Value;

                return result;
            }
        }

        public ExtractAnchor ToAPIExtractAnchor()
        {
            if (sdkTextAnchor == null)
            {
                return apiExtractAnchor;
            }
            else
            {
                var result = new ExtractAnchor();

                result.LeftOffset = sdkTextAnchor.XOffset;
                result.TopOffset = sdkTextAnchor.YOffset;
                result.Text = sdkTextAnchor.AnchorText;
                result.Index = sdkTextAnchor.Occurrence;
                result.CharacterIndex = sdkTextAnchor.Character;
                result.AnchorPoint = new TextAnchorPositionConverter(sdkTextAnchor.Position).ToAPIAnchorPoint();
                result.Width = sdkTextAnchor.Width;
                result.Height = sdkTextAnchor.Height;

                return result;
            }
        }
    }
}
