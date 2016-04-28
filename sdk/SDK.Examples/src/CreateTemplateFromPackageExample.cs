using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreateTemplateFromPackageExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new CreateTemplateFromPackageExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";
        public readonly string PackageNameNew = "Template name";
        public readonly string PackageDescription = "This is a package created using the e-SignLive SDK";
        public readonly string PackageEmailMessage = "This message should be delivered to all signers";
        public readonly string PackageSigner1First = "John";
        public readonly string PackageSigner1Last = "Smith";
        public readonly string PackageSigner2First = "Patty";
        public readonly string PackageSigner2Last = "Galant";

        public PackageId TemplateId { get; private set; }

        override public void Execute()
        {
            var document = DocumentBuilder.NewDocumentNamed(DocumentName)
                .WithId(DocumentId)
                .FromStream(fileStream1, DocumentType.PDF)
                .Build();

            var documentPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PackageDescription)
                .WithEmailMessage(PackageEmailMessage)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName(PackageSigner1First)
                    .WithLastName(PackageSigner1Last))
                .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                    .WithFirstName(PackageSigner2First)
                    .WithLastName(PackageSigner2Last))
                .WithDocument(document)
                .Build();

            packageId = eslClient.CreatePackage(documentPackage);

            TemplateId = eslClient.CreateTemplateFromPackage(packageId, PackageNameNew);
        }
    }
}

