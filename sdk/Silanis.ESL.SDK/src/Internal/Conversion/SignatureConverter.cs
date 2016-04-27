using Silanis.ESL.API;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace Silanis.ESL.SDK
{
    internal class SignatureConverter
    {
        private Signature sdkSignature;
        private Approval apiApproval;
        private Package package;

        public SignatureConverter(Signature sdkSignature)
        {
            this.sdkSignature = sdkSignature;
        }

        public SignatureConverter(Approval apiApproval, Package package)
        {
            this.apiApproval = apiApproval;
            this.package = package;
        }
        
        private static bool isPlaceHolder( Role role ) {
            return role.Signers.Count == 0;
        }
        
        private static bool isGroupRole(Role role)
        {
            return role.Signers.Count == 1 && role.Signers[0].Group != null;
        }
        
        public Signature ToSDKSignature() {

            SignatureBuilder signatureBuilder = null;
            foreach ( var role in package.Roles ) {
                if ( role.Id.Equals( apiApproval.Role ) ) {
                    if ( isPlaceHolder( role ) )
                    {
                        signatureBuilder = SignatureBuilder.SignatureFor(new Placeholder(role.Id));
                    }
                    else if ( isGroupRole( role ) )
                    {
                        signatureBuilder = SignatureBuilder.SignatureFor(new GroupId(role.Signers [0].Group.Id));
                    }
                    else
                    {
                        signatureBuilder = SignatureBuilder.SignatureFor(role.Signers [0].Email);
                    }
                }
            }

            if (apiApproval.Id != null)
            {
                signatureBuilder.WithId(new SignatureId(apiApproval.Id));
            }

            API.Field apiSignatureField = null;
            foreach ( var apiField in apiApproval.Fields ) {
                if (FieldType.SIGNATURE.getApiValue().Equals(apiField.Type)) {
                    apiSignatureField = apiField;
                } else {
                    var field = new FieldConverter( apiField ).ToSDKField();
                    signatureBuilder.WithField( field );
                }

            }

            if ( apiSignatureField == null ) {
                signatureBuilder.WithStyle( SignatureStyle.ACCEPTANCE );
                signatureBuilder.WithSize( 0, 0 );
            }
            else
            {
                signatureBuilder.WithStyle( new SignatureStyleConverter(apiSignatureField.Subtype).ToSDKSignatureStyle() )
                    .OnPage( apiSignatureField.Page.Value )
                        .AtPosition( apiSignatureField.Left.Value, apiSignatureField.Top.Value )
                        .WithSize( apiSignatureField.Width.Value, apiSignatureField.Height.Value );

                if ( apiSignatureField.Extract.Value ) {
                    signatureBuilder.WithPositionExtracted();
                }                   
            }
            
            var signature = signatureBuilder.Build();
            if (null != apiApproval.Accepted)
            {
                signature.Accepted = apiApproval.Accepted;
            }

            return signature;
        }

        public Approval ToAPIApproval ()
        {
            var result = new Approval();

            result.AddField(ToField(sdkSignature));

            if (sdkSignature.Id != null)
            {
                result.Id = sdkSignature.Id.Id;
            }

            foreach ( var field in sdkSignature.Fields ) {
                result.AddField( new FieldConverter( field ).ToAPIField() );
            }

            return result;
        }

        private API.Field ToField(Signature signature) {
            var result = new API.Field();

            result.Page = signature.Page;
            result.Name = signature.Name;
            result.Extract = signature.Extract;

            if (!signature.Extract)
            {
                result.Top = signature.Y;
                result.Left = signature.X;
                result.Width = signature.Width;
                result.Height = signature.Height;
            }

            if (signature.TextAnchor != null)
            {
                result.ExtractAnchor = new TextAnchorConverter(signature.TextAnchor).ToAPIExtractAnchor();
            }

            result.Type = FieldType.SIGNATURE.getApiValue();
            result.Subtype = signature.Style.getApiValue();
            return result;
        }       
    }
}

