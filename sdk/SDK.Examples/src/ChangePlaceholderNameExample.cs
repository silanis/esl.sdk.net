using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ChangePlaceholderNameExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new ChangePlaceholderNameExample().Run();
        }

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";
        public readonly string TEMPLATE_NAME = "ChangePlaceholderNameExample Template: " + DateTime.Now;
        public readonly string TEMPLATE_DESCRIPTION = "This is a template created using the e-SignLive SDK";
        public readonly string TEMPLATE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string TEMPLATE_SIGNER_FIRST = "John";
        public readonly string TEMPLATE_SIGNER_LAST = "Smith";
        public readonly string PLACEHOLDER_ID = "placeholderId";

        public Placeholder newPlaceholder, updatedPlaceholder;
        public DocumentPackage updatedTemplate;

        override public void Execute()
        {
            newPlaceholder = new Placeholder(PLACEHOLDER_ID, "placeholderName");
            updatedPlaceholder = new Placeholder(PLACEHOLDER_ID, "updatedPlaceholderName");

            DocumentPackage template = PackageBuilder.NewPackageNamed(TEMPLATE_NAME)
                .DescribedAs(TEMPLATE_DESCRIPTION)
                    .WithEmailMessage(TEMPLATE_EMAIL_MESSAGE)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TEMPLATE_SIGNER_FIRST)
                                .WithLastName(TEMPLATE_SIGNER_LAST))
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(newPlaceholder))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .WithId(DOCUMENT_ID)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(newPlaceholder)
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            PackageId templateId = eslClient.CreateTemplate(template);
            retrievedPackage = eslClient.GetPackage(templateId);

            eslClient.TemplateService.UpdatePlaceholder(templateId, updatedPlaceholder);

            updatedTemplate = eslClient.GetPackage(templateId);
        }
    }
}

