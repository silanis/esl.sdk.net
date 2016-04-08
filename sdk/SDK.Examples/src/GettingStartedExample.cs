using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class GettingStartedExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new GettingStartedExample().Run();
        }

        public DocumentPackage sentPackage;

        public readonly string DOCUMENT_NAME = "First Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1")
                                .WithCustomId("SIGNER1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
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
            var sessionToken = eslClient.SessionService.CreateSessionToken(packageId, "SIGNER1");
        }
    }
}

