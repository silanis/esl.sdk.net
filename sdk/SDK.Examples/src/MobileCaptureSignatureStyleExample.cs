using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class MobileCaptureSignatureStyleExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new MobileCaptureSignatureStyleExample().Run();
        }

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly int MOBILE_CAPTURE_SIGNATURE_PAGE = 0;
        public readonly int MOBILE_CAPTURE_SIGNATURE_POSITION_X = 500;
        public readonly int MOBILE_CAPTURE_SIGNATURE_POSITION_Y = 100;

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("John")
                            .WithLastName("Smith"))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                .FromStream(fileStream1, DocumentType.PDF)
                                .WithSignature(SignatureBuilder.MobileCaptureFor(email1)
                                    .OnPage(MOBILE_CAPTURE_SIGNATURE_PAGE)
                                    .AtPosition(MOBILE_CAPTURE_SIGNATURE_POSITION_X, MOBILE_CAPTURE_SIGNATURE_POSITION_Y)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

