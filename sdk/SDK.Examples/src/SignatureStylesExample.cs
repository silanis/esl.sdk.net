using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignatureStylesExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignatureStylesExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly int FullNameSignaturePage = 0;
        public readonly int FullNameSignaturePositionX = 500;
        public readonly int FullNameSignaturePositionY = 100;
        public readonly int InitialSignaturePage = 0;
        public readonly int InitialSignaturePositionX = 500;
        public readonly int InitialSignaturePositionY = 300;
        public readonly int HandDrawnSignaturePage = 0;
        public readonly int HandDrawnSignaturePositionX = 500;
        public readonly int HandDrawnSignaturePositionY = 500;

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("John")
                            .WithLastName("Smith"))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                .FromStream(fileStream1, DocumentType.PDF)
                                .WithSignature(SignatureBuilder.SignatureFor(email1)
                                    .OnPage(FullNameSignaturePage)
                                    .AtPosition(FullNameSignaturePositionX, FullNameSignaturePositionY)) 
                                .WithSignature(SignatureBuilder.InitialsFor(email1)
                                    .OnPage(InitialSignaturePage)
                                    .AtPosition(InitialSignaturePositionX, InitialSignaturePositionY))
                                .WithSignature(SignatureBuilder.CaptureFor(email1)
                                    .OnPage(HandDrawnSignaturePage)
                                    .AtPosition(HandDrawnSignaturePositionX, HandDrawnSignaturePositionY)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

