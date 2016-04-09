namespace Silanis.ESL.SDK
{
    internal class SignatureStyleConverter
    {
        private string apiSubtype;
        private SignatureStyle sdkSignatureStyle;
        
        public SignatureStyleConverter(string apiSubtype)
        {
            this.apiSubtype = apiSubtype;
            sdkSignatureStyle = null;
        }
        
        public SignatureStyle ToSDKSignatureStyle()
        {
            if (null!=sdkSignatureStyle)
            {
                return sdkSignatureStyle;
            }
            
            return SignatureStyle.valueOf(apiSubtype);
        }
    }
}
