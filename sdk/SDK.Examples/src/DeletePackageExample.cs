using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DeletePackageExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new DeletePackageExample().Run();
        }

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(package);
            eslClient.SendPackage(packageId);
            eslClient.PackageService.DeletePackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

