using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignatureImageExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignatureImageExample().Run();
        }

        public DocumentPackage SentPackage;

        override public void Execute()
        {
            var signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithCustomId("signer1")
                .WithFirstName("John1")
                .WithLastName("Smith1").Build();

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(signer1)
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);

            eslClient.SignatureImageService.GetSignatureImageForSender(senderUID, SignatureImageFormat.GIF);
            eslClient.SignatureImageService.GetSignatureImageForPackageRole(packageId, signer1.Id, SignatureImageFormat.JPG);
        }
    }
}

