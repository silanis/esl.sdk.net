using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class GettingStartedExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new GettingStartedExample().Run();
        }

        public DocumentPackage SentPackage;

        public readonly string DocumentName = "First Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1")
                                .WithCustomId("SIGNER1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.InitialsFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 200))
                                  .WithSignature(SignatureBuilder.CaptureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 300))
                                  )
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);

            // Optionally, get the session token for integrated signing.
            eslClient.SessionService.CreateSessionToken(packageId, "SIGNER1");
        }
    }
}

