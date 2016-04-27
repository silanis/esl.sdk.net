using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class UpdateTemplateWithPlaceholderExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new UpdateTemplateWithPlaceholderExample().Run();
        }

        public PackageId TemplateId;

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string TemplateName = "UpdateTemplateWithPlaceholderExample Template: "  + DateTime.Now;
        public readonly string TemplateDescription = "This is a template created using the e-SignLive SDK";
        public readonly string TemplateEmailMessage = "This message should be delivered to all signers";
        public readonly string TemplateSignerFirst = "John";
        public readonly string TemplateSignerLast = "Smith";

        public readonly string PlaceholderId = "PlaceholderId1";
        public readonly string Placeholder2Id = "PlaceholderId2";

        public DocumentPackage RetrievedTemplate, UpdatedTemplate;

        override public void Execute()
        {
            var template = PackageBuilder.NewPackageNamed(TemplateName)
                .DescribedAs(TemplateDescription)
                    .WithEmailMessage(TemplateEmailMessage)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TemplateSignerFirst)
                                .WithLastName(TemplateSignerLast))
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder(PlaceholderId)))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .WithId(DocumentId)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PlaceholderId))
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            TemplateId = eslClient.CreateTemplate(template);
            RetrievedTemplate = eslClient.GetPackage(TemplateId);

            eslClient.TemplateService.AddPlaceholder(TemplateId, new Placeholder(Placeholder2Id));
            UpdatedTemplate = eslClient.GetPackage(TemplateId);

            var newSignature = SignatureBuilder.SignatureFor(new Placeholder(Placeholder2Id))
                    .OnPage(0)
                    .AtPosition(400, 300).Build();

            eslClient.ApprovalService.AddApproval(UpdatedTemplate, DocumentId, newSignature);
            UpdatedTemplate = eslClient.GetPackage(TemplateId);
        }
    }
}

