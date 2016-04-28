using System.Collections.Generic;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class UpdateInjectedFieldsFromTemplateExample : SdkSample
    {
        public readonly string DocumentId = "doc1";
        public readonly string DocumentName = "First Document";

        public readonly string PackageSigner2Last = "Presley";
        public readonly string PackageSigner2Title = "The King";

        public readonly string PlaceholderId = "PlaceholderId1";
        public readonly string PackageDescription = "This is a package created using the e-SignLive SDK";
        public readonly string PackageEmailMessage = "This message should be delivered to all signers";
        public readonly string PackageEmailMessage2 = "Changed the email message";
        public readonly string PackageSigner1Company = "Acme Inc.";
        public readonly string PackageSigner1CustomId = "Signer1";
        public readonly string PackageSigner1First = "John";
        public readonly string PackageSigner1Last = "Smith";
        public readonly string PackageSigner1Title = "Manager";
        public readonly string PackageSigner2Company = "Elvis Presley International";
        public readonly string PackageSigner2CustomId = "Signer2";
        public readonly string PackageSigner2First = "Elvis";

        public static void Main(string[] args)
        {
            new UpdateInjectedFieldsFromTemplateExample().Run();
        }

        public override void Execute()
        {
            fileStream1 =
                File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);
            fileStream2 =
                File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);

            DocumentPackage template = PackageBuilder.NewPackageNamed("Template")
                .WithEmailMessage(PackageEmailMessage)
                .WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder(PlaceholderId)))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
                    .WithId(DocumentId)
                    .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PlaceholderId))
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .Build())
                    .Build();

            template.Id = eslClient.CreateTemplate(template);

            DocumentPackage newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PackageDescription)
                .WithEmailMessage(PackageEmailMessage2)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName(PackageSigner2First)
                    .WithLastName(PackageSigner2Last)
                    .WithTitle(PackageSigner2Title)
                    .WithCompany(PackageSigner2Company)
                    .WithCustomId(PlaceholderId))
                    .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                                  .WithInPerson()
                                  .Build())
                    .Build();

            packageId = eslClient.CreatePackageFromTemplate(template.Id, newPackage);
            retrievedPackage = eslClient.GetPackage(packageId);

            // You are not able to update a document itself.
            // So if you want to update your document itself, you need to change the document.
            // For this, you should create the same document with existing one, and exchange it with existing one.

            // Creating the same document with existing one.
            Document documentToChange = DocumentBuilder.NewDocumentNamed(DocumentName)
                .FromStream(fileStream2, DocumentType.PDF)
                .WithId(DocumentId)
                .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PlaceholderId))
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                    .Build();

            var injectedFields = new List<Field>();
            injectedFields.Add(FieldBuilder.TextField().WithName("AGENT_SIG_1").WithValue("AGENT_SIG_1").Build());

            // Adding injectedFields to new document
            documentToChange.AddFields(injectedFields);

            Document retrievedDocument = retrievedPackage.GetDocument(DocumentName);

            // Deleting the existing document.
            eslClient.PackageService.DeleteDocument(packageId, retrievedDocument.Id);

            // Uploading newly created document.
            eslClient.UploadDocument(documentToChange.FileName, documentToChange.Content, documentToChange,
                retrievedPackage);
        }
    }
}
