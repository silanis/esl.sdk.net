using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ChangePlaceholderNameExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new ChangePlaceholderNameExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string TemplateName = "ChangePlaceholderNameExample Template: " + DateTime.Now;
        public readonly string TemplateDescription = "This is a template created using the e-SignLive SDK";
        public readonly string TemplateEmailMessage = "This message should be delivered to all signers";
        public readonly string TemplateSignerFirst = "John";
        public readonly string TemplateSignerLast = "Smith";
        public readonly string PlaceholderId = "placeholderId";

        public Placeholder NewPlaceholder, UpdatedPlaceholder;
        public DocumentPackage UpdatedTemplate;

        override public void Execute()
        {
            NewPlaceholder = new Placeholder(PlaceholderId, "placeholderName");
            UpdatedPlaceholder = new Placeholder(PlaceholderId, "updatedPlaceholderName");

            var template = PackageBuilder.NewPackageNamed(TemplateName)
                .DescribedAs(TemplateDescription)
                    .WithEmailMessage(TemplateEmailMessage)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(TemplateSignerFirst)
                                .WithLastName(TemplateSignerLast))
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(NewPlaceholder))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .WithId(DocumentId)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(NewPlaceholder)
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            var templateId = eslClient.CreateTemplate(template);
            retrievedPackage = eslClient.GetPackage(templateId);

            eslClient.TemplateService.UpdatePlaceholder(templateId, UpdatedPlaceholder);

            UpdatedTemplate = eslClient.GetPackage(templateId);
        }
    }
}

