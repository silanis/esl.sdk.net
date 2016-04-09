using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ChangePackageStatusExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new ChangePackageStatusExample().Run();
        }

        public DocumentPackage SentPackage, TrashedPackage, RestoredPackage;

        public readonly string DocumentName = "First Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            SentPackage = eslClient.GetPackage(packageId);
            eslClient.ChangePackageStatusToDraft(packageId);
            retrievedPackage = eslClient.GetPackage( packageId );
            eslClient.PackageService.Trash(packageId);
            TrashedPackage = eslClient.GetPackage(packageId);
            eslClient.PackageService.Restore(packageId);
            RestoredPackage = eslClient.GetPackage(packageId);
        }
    }
}

