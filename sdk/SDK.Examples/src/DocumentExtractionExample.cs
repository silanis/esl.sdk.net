using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentExtractionExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new DocumentExtractionExample().Run();
        }

        public readonly string DOCUMENT_NAME = "My Document";

        override public void Execute()
        {
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/extract_document.pdf").FullName);

            DocumentPackage package = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1")
                                .WithCustomId("signer1"))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName("John2")
                                .WithLastName("Smith2")
                                .WithCustomId("signer2"))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email3)
                                .WithFirstName("John3")
                                .WithLastName("Smith3")
                                .WithCustomId("signer3"))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .EnableExtraction() )
                    .Build();

            packageId = eslClient.CreatePackage(package);
            eslClient.SendPackage(packageId);

            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

