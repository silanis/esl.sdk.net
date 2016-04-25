using System;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace Silanis.ESL.SDK
{
    internal class SignatureConverter
    {
        private Signature sdkSignature;
        private Silanis.ESL.API.Approval apiApproval;
        private Silanis.ESL.API.Package package;

        public SignatureConverter(Signature sdkSignature)
        {
            this.sdkSignature = sdkSignature;
        }

        public SignatureConverter(Silanis.ESL.API.Approval apiApproval, Silanis.ESL.API.Package package)
        {
            this.apiApproval = apiApproval;
            this.package = package;
        }
        
        private static bool isPlaceHolder( Silanis.ESL.API.Role role ) {
            return role.Signers.Count == 0;
        }
        
        private static bool isGroupRole(Silanis.ESL.API.Role role)
        {
            return role.Signers.Count == 1 && role.Signers[0].Group != null;
        }
        
        public Signature ToSDKSignature() {

            SignatureBuilder signatureBuilder = null;
            foreach ( Silanis.ESL.API.Role role in package.Roles ) {
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

            Silanis.ESL.API.Field apiSignatureField = null;
            foreach ( Silanis.ESL.API.Field apiField in apiApproval.Fields ) {
                if (FieldType.SIGNATURE.getApiValue().Equals(apiField.Type)) {
                    apiSignatureField = apiField;
                } else {
                    Field field = new FieldConverter( apiField ).ToSDKField();
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
            
            Signature signature = signatureBuilder.Build();
            if (null != apiApproval.Accepted)
            {
                signature.Accepted = apiApproval.Accepted;
            }

            return signature;
        }

        public Silanis.ESL.API.Approval ToAPIApproval ()
        {
            Silanis.ESL.API.Approval result = new Silanis.ESL.API.Approval();

            result.AddField(ToField(sdkSignature));

            if (sdkSignature.Id != null)
            {
                result.Id = sdkSignature.Id.Id;
            }

            foreach ( Field field in sdkSignature.Fields ) {
                result.AddField( new FieldConverter( field ).ToAPIField() );
            }

            return result;
        }

        private Silanis.ESL.API.Field ToField(Signature signature) {
            Silanis.ESL.API.Field result = new Silanis.ESL.API.Field();

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

