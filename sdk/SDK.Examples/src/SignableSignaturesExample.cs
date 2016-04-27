using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignableSignaturesExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignableSignaturesExample().Run();
        }

        public DocumentPackage SentPackage;

        private const string Signer1Id = "signer1Id";
        private const string Signer2Id = "signer2Id";
        private const string DocumentId = "documentId";
        private const string DocumentName = "First Document";

        public IList<Signature> Signer1SignableSignatures, Signer2SignableSignatures;

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithFirstName("John1")
                        .WithLastName("Smith1")
                        .WithCustomId(Signer1Id))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                        .WithFirstName("John2")
                        .WithLastName("Smith2")
                        .WithCustomId(Signer2Id))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                        .FromStream(fileStream1, DocumentType.PDF)
                        .WithId(DocumentId)
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                              .OnPage(0)
                              .AtPosition(100, 100))
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                              .OnPage(0)
                              .AtPosition(300, 100))
                        .WithSignature(SignatureBuilder.SignatureFor(email2)
                              .OnPage(0)
                              .AtPosition(500, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            SentPackage = eslClient.GetPackage(packageId);

            Signer1SignableSignatures = eslClient.ApprovalService.GetAllSignableSignatures(SentPackage, DocumentId, Signer1Id);
            Signer2SignableSignatures = eslClient.ApprovalService.GetAllSignableSignatures(SentPackage, DocumentId, Signer2Id);
        }
    }
}

