using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignDocumentsExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignDocumentsExample().Run();
        }

        public DocumentPackage RetrievedPackageBeforeSigning, RetrievedPackageAfterSigningApproval1, RetrievedPackageAfterSigningApproval2;

        private const string Document1Name = "First Document";
        private const string Document2Name = "Second Document";
        private const string Signer1Id = "signer1";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithCustomId(Signer1Id)
                                .WithFirstName("John1")
                                .WithLastName("Smith1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(Document1Name)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(senderEmail)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(Document2Name)
                                  .FromStream(fileStream2, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(senderEmail)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            RetrievedPackageBeforeSigning = eslClient.GetPackage(packageId);

            eslClient.SignDocuments(packageId);
            RetrievedPackageAfterSigningApproval1 = eslClient.GetPackage(packageId);

            eslClient.SignDocuments(packageId, Signer1Id);
            RetrievedPackageAfterSigningApproval2 = eslClient.GetPackage(packageId);
        }
    }
}

