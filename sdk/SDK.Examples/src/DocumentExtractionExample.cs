using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentExtractionExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new DocumentExtractionExample().Run();
        }

        public readonly string DocumentName = "My Document";

        override public void Execute()
        {
            fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/extract_document.pdf").FullName);

            var package = PackageBuilder.NewPackageNamed(PackageName)
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
                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .EnableExtraction() )
                    .Build();

            packageId = eslClient.CreatePackage(package);
            eslClient.SendPackage(packageId);

            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

