using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class DocumentConverter
    {
        private Document sdkDocument;
        private Silanis.ESL.API.Document apiDocument;
        private Silanis.ESL.API.Package apiPackage;
        /*
         * Construct with API objects
         */
        public DocumentConverter(Silanis.ESL.API.Document apiDocument, Silanis.ESL.API.Package apiPackage)
        {
            this.apiDocument = apiDocument;
            this.apiPackage = apiPackage;
        }
        /*
         * Construct with SDK object
         */
        public DocumentConverter(Document sdkDocument)
        {
            this.sdkDocument = sdkDocument;
        }

        internal Document ToSDKDocument()
        {
            if (apiDocument == null)
            {
                return sdkDocument;
            }

            DocumentBuilder documentBuilder = DocumentBuilder.NewDocumentNamed(apiDocument.Name)
                .WithId(apiDocument.Id)
                .AtIndex(apiDocument.Index.Value)
                    .WithDescription(apiDocument.Description);
            documentBuilder.WithExternal(new ExternalConverter(apiDocument.External).ToSDKExternal());
            foreach (Approval apiApproval in apiDocument.Approvals)
            {
                documentBuilder.WithSignature(new SignatureConverter(apiApproval, apiPackage).ToSDKSignature());
            }

            foreach (Silanis.ESL.API.Field apiField in apiDocument.Fields)
            {
                Field sdkField = new FieldConverter(apiField).ToSDKField();
                if (!FieldStyle.BOUND_QRCODE.getApiValue().Equals(apiField.Subtype))
                {
                    documentBuilder.WithInjectedField(sdkField);
                }
                else
                {
                    documentBuilder.WithQRCode(sdkField);
                }
            }

            return documentBuilder.Build();
        }

        internal Silanis.ESL.API.Document ToAPIDocument(Silanis.ESL.API.Package apiPackage)
        {
            if (sdkDocument == null)
            {
                return apiDocument;
            }

            Silanis.ESL.API.Document doc = ToAPIDocument();

            foreach (Signature signature in sdkDocument.Signatures)
            {
                Silanis.ESL.API.Approval approval = new SignatureConverter(signature).ToAPIApproval();

                if (signature.IsPlaceholderSignature())
                {
                    approval.Role = signature.RoleId.Id;
                }
                else if (signature.IsGroupSignature())
                {
                    approval.Role = FindRoleIdForGroup(signature.GroupId, apiPackage);
                }
                else
                {
                    approval.Role = FindRoleIdForSigner(signature.SignerEmail, apiPackage);
                }
                doc.AddApproval(approval);
            }

            foreach (Field field in sdkDocument.Fields)
            {
                doc.AddField(new FieldConverter(field).ToAPIField());
            }

            foreach (Field field in sdkDocument.QRCodes)
            {
                doc.AddField(new FieldConverter(field).ToAPIField());
            }

            return doc;
        }

        internal Silanis.ESL.API.Document ToAPIDocument()
        {
            if (sdkDocument == null)
            {
                return apiDocument;
            }

            Silanis.ESL.API.Document doc = new Silanis.ESL.API.Document();

            doc.Name = sdkDocument.Name;
            doc.Index = sdkDocument.Index;
            doc.Extract = sdkDocument.Extract;
            doc.External = new ExternalConverter(sdkDocument.External).ToAPIExternal();

            if (sdkDocument.Id != null)
            {
                doc.Id = sdkDocument.Id;
            }

            if (sdkDocument.Description != null)
            {
                doc.Description = sdkDocument.Description;
            }

            return doc;
        }

        private string FindRoleIdForGroup(GroupId groupId, Silanis.ESL.API.Package createdPackage)
        {
            foreach (Silanis.ESL.API.Role role in createdPackage.Roles)
            {
                if (role.Signers.Count > 0 && role.Signers[0].Group != null)
                {
                    if (groupId.Id.Equals(role.Signers[0].Group.Id))
                    {
                        return role.Id;
                    }
                }
            }

            throw new EslException(String.Format("No Role found for group with id {0}", groupId.Id), null);
        }

        private string FindRoleIdForSigner(string signerEmail, Silanis.ESL.API.Package createdPackage)
        {
            foreach (Silanis.ESL.API.Role role in createdPackage.Roles)
            {
                if (role.Signers.Count > 0 && role.Signers[0].Email != null)
                {
                    if (signerEmail.Equals(role.Signers[0].Email))
                    {
                        return role.Id;
                    }
                }
            }

            throw new EslException(String.Format("No Role found for signer email {0}", signerEmail), null);
        }
    }
}

