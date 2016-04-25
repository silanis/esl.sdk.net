using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreateTemplateFromPackageExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new CreateTemplateFromPackageExample().Run();
        }

        private PackageId templateId;

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";
        public readonly string PACKAGE_NAME_NEW = "Template name";
        public readonly string PACKAGE_DESCRIPTION = "This is a package created using the e-SignLive SDK";
        public readonly string PACKAGE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string PACKAGE_SIGNER1_FIRST = "John";
        public readonly string PACKAGE_SIGNER1_LAST = "Smith";
        public readonly string PACKAGE_SIGNER2_FIRST = "Patty";
        public readonly string PACKAGE_SIGNER2_LAST = "Galant";

        public PackageId TemplateId
        {
            get
            {
                return templateId;
            }
        }

        override public void Execute()
        {
            Document document = DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                .WithId(DOCUMENT_ID)
                .FromStream(fileStream1, DocumentType.PDF)
                .Build();

            DocumentPackage documentPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(PACKAGE_DESCRIPTION)
                .WithEmailMessage(PACKAGE_EMAIL_MESSAGE)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName(PACKAGE_SIGNER1_FIRST)
                    .WithLastName(PACKAGE_SIGNER1_LAST))
                .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                    .WithFirstName(PACKAGE_SIGNER2_FIRST)
                    .WithLastName(PACKAGE_SIGNER2_LAST))
                .WithDocument(document)
                .Build();

            packageId = eslClient.CreatePackage(documentPackage);

            templateId = eslClient.CreateTemplateFromPackage(packageId, PACKAGE_NAME_NEW);
        }
    }
}

