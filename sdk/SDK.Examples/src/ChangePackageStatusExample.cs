using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ChangePackageStatusExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new ChangePackageStatusExample().Run();
        }

        public DocumentPackage sentPackage, trashedPackage, restoredPackage;

        public readonly string DOCUMENT_NAME = "First Document";

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            sentPackage = eslClient.GetPackage(packageId);
            eslClient.ChangePackageStatusToDraft(packageId);
            retrievedPackage = eslClient.GetPackage( packageId );
            eslClient.PackageService.Trash(packageId);
            trashedPackage = eslClient.GetPackage(packageId);
            eslClient.PackageService.Restore(packageId);
            restoredPackage = eslClient.GetPackage(packageId);
        }
    }
}

