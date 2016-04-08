using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class UpdateTemplateWithPlaceholderExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new UpdateTemplateWithPlaceholderExample().Run();
        }

        public PackageId templateId;

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";
        public readonly string TEMPLATE_NAME = "UpdateTemplateWithPlaceholderExample Template: "  + DateTime.Now;
        public readonly string TEMPLATE_DESCRIPTION = "This is a template created using the e-SignLive SDK";
        public readonly string TEMPLATE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string TEMPLATE_SIGNER_FIRST = "John";
        public readonly string TEMPLATE_SIGNER_LAST = "Smith";

        public readonly string PLACEHOLDER_ID = "PlaceholderId1";
        public readonly string PLACEHOLDER2_ID = "PlaceholderId2";

        public DocumentPackage retrievedTemplate, updatedTemplate;

        override public void Execute()
        {
            var template = PackageBuilder.NewPackageNamed(TEMPLATE_NAME)
                .DescribedAs(TEMPLATE_DESCRIPTION)
                    .WithEmailMessage(TEMPLATE_EMAIL_MESSAGE)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TEMPLATE_SIGNER_FIRST)
                                .WithLastName(TEMPLATE_SIGNER_LAST))
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder(PLACEHOLDER_ID)))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .WithId(DOCUMENT_ID)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PLACEHOLDER_ID))
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            templateId = eslClient.CreateTemplate(template);
            retrievedTemplate = eslClient.GetPackage(templateId);

            eslClient.TemplateService.AddPlaceholder(templateId, new Placeholder(PLACEHOLDER2_ID));
            updatedTemplate = eslClient.GetPackage(templateId);

            var newSignature = SignatureBuilder.SignatureFor(new Placeholder(PLACEHOLDER2_ID))
                    .OnPage(0)
                    .AtPosition(400, 300).Build();

            eslClient.ApprovalService.AddApproval(updatedTemplate, DOCUMENT_ID, newSignature);
            updatedTemplate = eslClient.GetPackage(templateId);
        }
    }
}

