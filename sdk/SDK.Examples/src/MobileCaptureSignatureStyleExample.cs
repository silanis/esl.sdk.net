using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class MobileCaptureSignatureStyleExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new MobileCaptureSignatureStyleExample().Run();
        }

        public readonly string DocumentName = "First Document";
        public readonly int MobileCaptureSignaturePage = 0;
        public readonly int MobileCaptureSignaturePositionX = 500;
        public readonly int MobileCaptureSignaturePositionY = 100;

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("John")
                            .WithLastName("Smith"))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                .FromStream(fileStream1, DocumentType.PDF)
                                .WithSignature(SignatureBuilder.MobileCaptureFor(email1)
                                    .OnPage(MobileCaptureSignaturePage)
                                    .AtPosition(MobileCaptureSignaturePositionX, MobileCaptureSignaturePositionY)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

