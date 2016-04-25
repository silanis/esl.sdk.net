using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class UpdateInjectedFieldsFromTemplateExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new UpdateInjectedFieldsFromTemplateExample().Run();
        }

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";
        public readonly string PACKAGE_DESCRIPTION = "This is a package created using the e-SignLive SDK";
        public readonly string PACKAGE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string PACKAGE_EMAIL_MESSAGE2 = "Changed the email message";
        public readonly string PACKAGE_SIGNER1_FIRST = "John";
        public readonly string PACKAGE_SIGNER1_LAST = "Smith";
        public readonly string PACKAGE_SIGNER1_TITLE = "Manager";
        public readonly string PACKAGE_SIGNER1_COMPANY = "Acme Inc.";
        public readonly string PACKAGE_SIGNER1_CUSTOM_ID = "Signer1";

        public readonly string PACKAGE_SIGNER2_FIRST = "Elvis";
        public readonly string PACKAGE_SIGNER2_LAST = "Presley";
        public readonly string PACKAGE_SIGNER2_TITLE = "The King";
        public readonly string PACKAGE_SIGNER2_COMPANY = "Elvis Presley International";
        public readonly string PACKAGE_SIGNER2_CUSTOM_ID = "Signer2";

        public readonly string PLACEHOLDER_ID = "PlaceholderId1";

        override public void Execute()
        {
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);
            this.fileStream2 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);

            DocumentPackage template = PackageBuilder.NewPackageNamed("Template")
                    .WithEmailMessage(PACKAGE_EMAIL_MESSAGE)
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder(PLACEHOLDER_ID)))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithId(DOCUMENT_ID)
                                  .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PLACEHOLDER_ID))
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .Build())
                    .Build();

            template.Id = eslClient.CreateTemplate(template);

            DocumentPackage newPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PACKAGE_DESCRIPTION)
                    .WithEmailMessage(PACKAGE_EMAIL_MESSAGE2)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(PACKAGE_SIGNER2_FIRST)
                                .WithLastName(PACKAGE_SIGNER2_LAST)
                                .WithTitle(PACKAGE_SIGNER2_TITLE)
                                .WithCompany(PACKAGE_SIGNER2_COMPANY)
                                .WithCustomId(PLACEHOLDER_ID))
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
            Document documentToChange = DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                .FromStream(fileStream2, DocumentType.PDF)
                    .WithId(DOCUMENT_ID)
                    .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PLACEHOLDER_ID))
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                    .Build();

            List<Field> injectedFields = new List<Field>();
            injectedFields.Add(FieldBuilder.TextField().WithName("AGENT_SIG_1").WithValue("AGENT_SIG_1").Build());

            // Adding injectedFields to new document
            documentToChange.AddFields(injectedFields);

            Document retrievedDocument = retrievedPackage.GetDocument(DOCUMENT_NAME);

            // Deleting the existing document.
            eslClient.PackageService.DeleteDocument(packageId, retrievedDocument.Id);

            // Uploading newly created document.
            eslClient.UploadDocument(documentToChange.FileName, documentToChange.Content, documentToChange, retrievedPackage);
        }
    }
}

