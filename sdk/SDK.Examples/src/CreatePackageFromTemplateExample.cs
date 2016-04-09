using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageFromTemplateExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new CreatePackageFromTemplateExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string PackageDescription = "This is a package created using the e-SignLive SDK";
        public readonly string PackageEmailMessage = "This message should be delivered to all signers";
        public readonly string PackageEmailMessage2 = "Changed the email message";
        public readonly string PackageSigner1First = "John";
        public readonly string PackageSigner1Last = "Smith";
        public readonly string PackageSigner1Title = "Manager";
        public readonly string PackageSigner1Company = "Acme Inc.";
        public readonly string PackageSigner1CustomId = "Signer1";

        public readonly string PackageSigner2First = "Elvis";
        public readonly string PackageSigner2Last = "Presley";
        public readonly string PackageSigner2Title = "The King";
        public readonly string PackageSigner2Company = "Elvis Presley International";
        public readonly string PackageSigner2CustomId = "Signer2";

        override public void Execute()
        {
            var template = PackageBuilder.NewPackageNamed("Template")
                .DescribedAs("first message")
                .WithEmailMessage(PackageEmailMessage)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName(PackageSigner1First)
                    .WithLastName(PackageSigner1Last)
                    .WithTitle(PackageSigner1Title)
                    .WithCompany(PackageSigner1Company)
                    .WithCustomId(PackageSigner1CustomId))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithId(DocumentId)
                    .Build())
                .Build();

            template.Id = eslClient.CreateTemplate(template);

            var newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PackageDescription)
                .WithEmailMessage(PackageEmailMessage2)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                    .WithFirstName(PackageSigner2First)
                    .WithLastName(PackageSigner2Last)
                    .WithTitle(PackageSigner2Title)
                    .WithCompany(PackageSigner2Company)
                    .WithCustomId(PackageSigner2CustomId))
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                    .WithoutInPerson()
                    .WithoutDecline()
                    .WithoutOptOut()
                    .WithWatermark()
                    .Build())
                .Build();

            packageId = eslClient.CreatePackageFromTemplate(template.Id, newPackage);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}
