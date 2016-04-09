using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageFromTemplateWithReplacingPlaceholderExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new CreatePackageFromTemplateWithReplacingPlaceholderExample().Run();
        }

        public PackageId TemplateId;

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string TemplateName = "CreatePackageFromTemplateWithReplacingPlaceholderExample Template: " + DateTime.Now;
        public readonly string TemplateDescription = "This is a template created using the e-SignLive SDK";
        public readonly string TemplateEmailMessage = "This message should be delivered to all signers";
        public readonly string TemplateSignerFirst = "John";
        public readonly string TemplateSignerLast = "Smith";

        public readonly string PackageDescription = "This is a package created using the e-SignLive SDK";
        public readonly string PackageEmailMessage = "This message should be delivered to all signers";
        public readonly string PackageSignerFirst = "Patty";
        public readonly string PackageSignerLast = "Galant";

        public readonly string PlaceholderId = "PlaceholderId1";

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

            var newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PackageDescription)
                    .WithEmailMessage(PackageEmailMessage)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName(PackageSignerFirst)
                                .WithLastName(PackageSignerLast).Replacing(new Placeholder(PlaceholderId)))
                    .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .Build();

            packageId = eslClient.CreatePackageFromTemplate(TemplateId, newPackage);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

